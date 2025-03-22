using PrimeiraAPI.DTO.BookDTO;
using PrimeiraAPI.Models;

namespace PrimeiraAPI.Services.BookServices;

public interface IBook
{
    Task<Response<List<Book>>> ListBooks();
    Task<Response<Book>> GetBookById(int id);
    Task<Response<List<Book>>> GetBookByAuthorId(int authorId);
    Task<Response<List<Book>>> CreateBook(BookCreateDTO bookDTO);
    Task<Response<List<Book>>> UpdateBook(BookUpdateDTO bookDTO);
    Task<Response<List<Book>>> RemoveBook(int id);
}