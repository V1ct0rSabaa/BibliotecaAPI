using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Data;
using PrimeiraAPI.DTO.BookDTO;
using PrimeiraAPI.Models;

namespace PrimeiraAPI.Services.BookServices;

public class BookService : IBook
{
    private readonly AppDbContext _context;

    private readonly string textGetAll = "Todos os Livros foram coletados!";
    private readonly string textBookNotFound = "Nenhum Livro localizado!";
    private readonly string textBookFound = "Livro Localizado!";
    private readonly string textBookCreated = "Livro adicionado com sucesso!";
    private readonly string textBookUpdated = "Livro atualizado com sucesso!";
    private readonly string textBookDeleted = "Livro removido com sucesso!";
    private readonly string textAuthorNotFound = "Nenhum registro localizado!";

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Book>>> ListBooks()
    {
        var response = new Response<List<Book>>();
        try
        {
            var books = await _context.Books.ToListAsync();
            response.Data = books;
            response.Text = textGetAll;
            return response;
        }
        catch (Exception ex)
        {
            response.Text = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<Response<Book>> GetBookById(int bookId)
    {
        var response = new Response<Book>();
        try
        {
            var book = await _context.Books.Include(a => a.Author)
            .FirstOrDefaultAsync(book => book.Id == bookId);
            if (book == null)
            {
                response.Text = textBookNotFound;
                return response;
            }
            response.Data = book;
            response.Text = textBookFound;
            return response;
        }
        catch (Exception ex)
        {
            response.Text = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<Response<List<Book>>> GetBookByAuthorId(int authorId)
    {
        var response = new Response<List<Book>>();
        try
        {
            var book = await _context.Books
                .Include(a => a.Author)
                .Where(book => book.Author.Id == authorId)
                .ToListAsync();

            if (book == null)
            {
                response.Text = textAuthorNotFound;
                return response;
            }

            response.Data = book;
            response.Text = textBookFound;
            return response;
        }
        catch (Exception ex)
        {
            response.Text = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<Response<List<Book>>> CreateBook(BookCreateDTO bookDTO)
    {
        var response = new Response<List<Book>>();
        try
        {
            // verificar se já tem um autor no db
            var author = await _context.Authors.
                FirstOrDefaultAsync(author => author.Id == bookDTO.AuthorId);
            if (author == null)
            {
                response.Text = textAuthorNotFound;
                return response;
            }
            var book = new Book()
            {
                Title = bookDTO.Title,
                Author = author
            };

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            response.Data = await _context.Books.ToListAsync();
            response.Text = textBookCreated;
            return response;
        }
        catch (Exception ex)
        {
            response.Text = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<Response<List<Book>>> UpdateBook(BookUpdateDTO bookDTO)
    {
        var response = new Response<List<Book>>();
        try
        {
            var book = await _context.Books
            .Include(author => author.Id == bookDTO.AuthorId)
            .FirstOrDefaultAsync(book => book.Id == bookDTO.Id);
            if (book == null)
            {
                response.Text = textBookNotFound;
                return response;
            }
            book.Title = bookDTO.Title ?? book.Title;
            // atualização do Id
            if (bookDTO.AuthorId.HasValue)
            {
                var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == bookDTO.AuthorId);
                if(author!= null){
                    book.Author = author;
                }
            }

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            response.Data = await _context.Books.ToListAsync();
            response.Text = textBookUpdated;
            return response;
        }
        catch (Exception ex)
        {
            response.Text = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<Response<List<Book>>> RemoveBook(int id)
    {
        var response = new Response<List<Book>>();
        try
        {
            var book = await _context.Books.
                FirstOrDefaultAsync(livro => livro.Id == id);
            if (book == null)
            {
                response.Text = textBookNotFound;
                return response;
            }
            _context.Remove(book);
            await _context.SaveChangesAsync();

            response.Data = await _context.Books.ToListAsync();
            response.Text = textBookDeleted;
            return response;
        }
        catch (Exception ex)
        {
            response.Text = ex.Message;
            response.Status = false;
            return response;
        }
    }
}