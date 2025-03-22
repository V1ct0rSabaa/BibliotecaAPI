using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.DTO.BookDTO;
using PrimeiraAPI.Models;
using PrimeiraAPI.Services.BookServices;
// using PrimeiraAPI.DTO.Book;

namespace PrimeiraAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBook _bookInterface;
    public BookController(IBook bookInterface)
    {
        _bookInterface = bookInterface;
    }

    [HttpGet("ListBooks")]
    public async Task<ActionResult<Response<List<Book>>>> ListBooks()
    {
        var books = await _bookInterface.ListBooks();
        return Ok(books);
    }

    [HttpGet("GetBookById/{id}")]
    public async Task<ActionResult<Response<Book>>> GetBookById(int id)
    {
        var Book = await _bookInterface.GetBookById(id);
        return Ok(Book);
    }

    [HttpGet("GetBookByAuthorId/{id}")]
    public async Task<ActionResult<Response<Book>>> GetBookByAuthorId(int authorId)
    {
        var Book = await _bookInterface.GetBookByAuthorId(authorId);
        return Ok(Book);
    }

    [HttpPost("CreateBook")]
    public async Task<ActionResult<Response<List<Book>>>> CriarLivro(BookCreateDTO bookDTO)
    {
        var book = await _bookInterface.CreateBook(bookDTO);
        return Ok(book);
    }

    [HttpPut("UpdateBook/{id}")]
    public async Task<ActionResult<Response<List<Book>>>> UpdateBook(BookUpdateDTO bookDTO)
    {
        var book = await _bookInterface.UpdateBook(bookDTO);
        return Ok(book);
    }

    [HttpDelete("RemoveBook/{id}")]
    public async Task<ActionResult<Response<List<Author>>>> RemoveBook(int id)
    {
        var books = await _bookInterface.RemoveBook(id);
        return Ok(books);
    }
}