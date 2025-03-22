using PrimeiraAPI.DTO.AuthorDTO;
using PrimeiraAPI.Models;
namespace PrimeiraAPI.Services.AuthorServices;

public interface IAuthor
{
    Task<Response<List<Author>>> ListAuthors();
    Task<Response<Author>> GetAuthorById(int authorId);
    Task<Response<Author>> GetAuthorByBookId(int bookId);
    Task<Response<List<Author>>> RemoveAuthor(int authorId);

    Task<Response<List<Author>>> CreateAuthor(AuthorCreateDTO authorDTO);
    Task<Response<List<Author>>> UpdateAuthor(AuthorUpdateDTO authorDTO);
}