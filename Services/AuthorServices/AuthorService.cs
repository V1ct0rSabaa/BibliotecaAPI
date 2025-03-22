using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Data;
using PrimeiraAPI.DTO.AuthorDTO;
using PrimeiraAPI.Models;

namespace PrimeiraAPI.Services.AuthorServices;

public class AuthorService : IAuthor
{
    private readonly AppDbContext _context;

    private readonly string textGetAll = "Todos os Autores foram coletados!";
    private readonly string textBookNotFound = "Nenhum registro localizado!";
    private readonly string textAuthorFound = "Autor Localizado!";
    private readonly string textAuthorNotFound = "Nenhum Autor localizado!";
    private readonly string textAuthorCreated = "Dados do Autor adicionados com sucesso!";
    private readonly string textAuthorUpdated = "Dados do Autor atualizados com sucesso!";
    private readonly string textAuthorDeleted = "Dados do Autor foram removidos com Sucesso!";

    public AuthorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Author>>> ListAuthors()
    {
        var response = new Response<List<Author>>();
        try
        {
            var authors = await _context.Authors.ToListAsync(); //async pois sera preenchido pelo DB
            response.Data = authors;
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

    public async Task<Response<Author>> GetAuthorById(int authorId)
    {
        var response = new Response<Author>();
        try
        {
            var author = await _context.Authors.FirstOrDefaultAsync(autorBanco => autorBanco.Id == authorId);
            if (author == null)
            {
                response.Text = textBookNotFound;
                return response;
            }
            response.Data = author;
            response.Text = textAuthorFound;
            return response;
        }
        catch (Exception ex)
        {
            response.Text = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<Response<Author>> GetAuthorByBookId(int bookId)
    {
        var response = new Response<Author>();
        try
        {
            var book = await _context.Books
                .Include(a => a.Author)
                .FirstOrDefaultAsync(livroBanco => livroBanco.Id == bookId);
            // Busca o livro pelo id e carrega o autor informado no livro
            if (book == null)
            {
                response.Text = textBookNotFound;
                return response;
            }
            response.Data = book.Author;
            response.Text = textAuthorFound;
            return response;
        }
        catch (Exception ex)
        {
            response.Text = ex.Message;
            response.Status = false;
            return response;
        }
    }
    public async Task<Response<List<Author>>> RemoveAuthor(int authorId)
    {
        var response = new Response<List<Author>>(); // request da lista de autores no db
        try
        {
            var author = await _context.Authors
                .FirstOrDefaultAsync(autorBanco => autorBanco.Id == authorId);
            if (author == null)
            {
                response.Text = textAuthorNotFound;
                return response;
            }
            _context.Remove(author); // DELETE autor especifico do db
            await _context.SaveChangesAsync();

            response.Data = await _context.Authors.ToListAsync();
            response.Text = textAuthorDeleted;
            return response;
        }
        catch (Exception ex)
        {
            response.Text = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<Response<List<Author>>> CreateAuthor(AuthorCreateDTO authorDTO)
    {
        var response = new Response<List<Author>>();
        try
        {
            var author = new Author()
            {
                Name = authorDTO.Name,
                Lastname = authorDTO.Lastname,
                Nationality = authorDTO.Nationality
            };

            _context.Add(author);
            await _context.SaveChangesAsync(); // fazendo INSERT no banco e atualizando

            response.Data = await _context.Authors.ToListAsync();
            response.Text = textAuthorCreated;

            return response;
        }
        catch (Exception ex)
        {
            response.Text = ex.Message;
            response.Status = false;
            return response;
        }
    }
    public async Task<Response<List<Author>>> UpdateAuthor(AuthorUpdateDTO authorDTO){
        var response = new Response<List<Author>>();
           try{
             var author = await _context.Authors.
                FirstOrDefaultAsync(autorBanco => autorBanco.Id == authorDTO.Id);
            if(author == null){
                response.Text = textAuthorNotFound;
                return response;
            }
            author.Name = authorDTO.Name;
            author.Lastname = authorDTO.Lastname;
            author.Nationality = authorDTO.Nationality;
            _context.Update(author);
            await _context.SaveChangesAsync();

            response.Data = await _context.Authors.ToListAsync();
            response.Text = textAuthorUpdated;
            return response;
           }
           catch(Exception ex){
            response.Text = ex.Message;
            response.Status = false;
            return response;
           }
    }
}