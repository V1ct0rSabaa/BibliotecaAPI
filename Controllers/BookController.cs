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

    /// <summary>
    /// Retrieves a list of all books.
    /// </summary>
    /// <remarks>
    /// This endpoint returns a list of all books available in the system.
    /// </remarks>
    /// <response code="200">Returns the list of books</response>
    [HttpGet("ListBooks")]
    public async Task<ActionResult<Response<List<Book>>>> ListBooks()
    {
        var books = await _bookInterface.ListBooks();
        return Ok(books);
    }

    /// <summary>
    /// Retrieves a book by its ID.
    /// </summary>
    /// <param name="id">The ID of the book to retrieve.</param>
    /// <response code="200">Returns the book with the specified ID</response>
    /// <response code="404">If the book is not found</response>
    [HttpGet("GetBookById/{id}")]
    public async Task<ActionResult<Response<Book>>> GetBookById(int id)
    {
        var Book = await _bookInterface.GetBookById(id);
        return Ok(Book);
    }

    /// <summary>
    /// Retrieves a book by the author's ID.
    /// </summary>
    /// <param name="authorId">The ID of the author whose book to retrieve.</param>
    /// <response code="200">Returns the book associated with the specified author ID</response>
    /// <response code="404">If no book is found for the given author ID</response>
    [HttpGet("GetBookByAuthorId/{authorId}")]
    public async Task<ActionResult<Response<Book>>> GetBookByAuthorId(int authorId)
    {
        var Book = await _bookInterface.GetBookByAuthorId(authorId);
        return Ok(Book);
    }

    /// <summary>
    /// Creates a new book.
    /// </summary>
    /// <param name="bookDTO">The data transfer object containing book details.</param>
    /// <response code="201">Returns the created book</response>
    /// <response code="400">If the input data is invalid</response>
    [HttpPost("CreateBook")]
    public async Task<ActionResult<Response<List<Book>>>> CriarLivro(BookCreateDTO bookDTO)
    {
        var book = await _bookInterface.CreateBook(bookDTO);
        return Ok(book);
    }

    /// <summary>
    /// Updates an existing book.
    /// </summary>
    /// <param name="bookDTO">The data transfer object containing updated book details.</param>
    /// <response code="200">Returns the updated book</response>
    /// <response code="404">If the book to update is not found</response>
    [HttpPut("UpdateBook/{id}")]
    public async Task<ActionResult<Response<List<Book>>>> UpdateBook(BookUpdateDTO bookDTO)
    {
        var book = await _bookInterface.UpdateBook(bookDTO);
        return Ok(book);
    }

    /// <summary>
    /// Removes a book by its ID.
    /// </summary>
    /// <param name="id">The ID of the book to remove.</param>
    /// <response code="200">Returns the list of remaining books</response>
    /// <response code="404">If the book to remove is not found</response>
    [HttpDelete("RemoveBook/{id}")]
    public async Task<ActionResult<Response<List<Author>>>> RemoveBook(int id)
    {
        var books = await _bookInterface.RemoveBook(id);
        return Ok(books);
    }
}