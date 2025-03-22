using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.DTO.AuthorDTO;
using PrimeiraAPI.Models;
using PrimeiraAPI.Services.AuthorServices;

namespace PrimeiraAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthor _authorInterface;
    public AuthorController(IAuthor authorInterface)
    {
        _authorInterface = authorInterface;
    }

    /// <summary>
    /// Retrieves a list of all authors.
    /// </summary>
    /// <returns>A list of authors.</returns>
    /// <response code="200">Returns the list of authors.</response>
    [HttpGet("ListAuthors")]
    public async Task<ActionResult<Response<List<Author>>>> ListAuthors()
    {
        var authors = await _authorInterface.ListAuthors();
        return Ok(authors);
    }

    /// <summary>
    /// Retrieves an author by their ID.
    /// </summary>
    /// <param name="id">The ID of the author.</param>
    /// <returns>The author with the specified ID.</returns>
    /// <response code="200">Returns the author with the specified ID.</response>
    /// <response code="404">If the author is not found.</response>
    [HttpGet("GetAuthorById/{id}")]
    public async Task<ActionResult<Response<Author>>> GetAuthorById(int id)
    {
        var author = await _authorInterface.GetAuthorById(id);
        return Ok(author);
    }

    /// <summary>
    /// Retrieves an author by the ID of a book they wrote.
    /// </summary>
    /// <param name="bookId">The ID of the book.</param>
    /// <returns>The author of the specified book.</returns>
    /// <response code="200">Returns the author of the specified book.</response>
    /// <response code="404">If the author is not found.</response>
    [HttpGet("GetAuthorByBookId/{bookId}")]
    public async Task<ActionResult<Response<Author>>> GetAuthorByBook(int bookId)
    {
        var author = await _authorInterface.GetAuthorByBookId(bookId);
        return Ok(author);
    }

    /// <summary>
    /// Creates a new author.
    /// </summary>
    /// <param name="authorDTO">The data for the new author.</param>
    /// <returns>The updated list of authors.</returns>
    /// <response code="201">Returns the updated list of authors after creation.</response>
    /// <response code="400">If the input data is invalid.</response>
    [HttpPost("CreateAuthor")]
    public async Task<ActionResult<Response<List<Author>>>> CreateAuthor(AuthorCreateDTO authorDTO)
    {
        var authors = await _authorInterface.CreateAuthor(authorDTO);
        return Ok(authors);
    }

    /// <summary>
    /// Removes an author by their ID.
    /// </summary>
    /// <param name="id">The ID of the author to remove.</param>
    /// <returns>The updated list of authors.</returns>
    /// <response code="200">Returns the updated list of authors after removal.</response>
    /// <response code="404">If the author is not found.</response>
    [HttpDelete("RemoveAuthor/{id}")]
    public async Task<ActionResult<Response<List<Author>>>> RemoveAuthor(int id)
    {
        var result = await _authorInterface.RemoveAuthor(id);
        return Ok(result);
    }

    /// <summary>
    /// Updates an existing author.
    /// </summary>
    /// <param name="authorDTO">The updated data for the author.</param>
    /// <returns>The updated list of authors.</returns>
    /// <response code="200">Returns the updated list of authors after the update.</response>
    /// <response code="400">If the input data is invalid.</response>
    /// <response code="404">If the author is not found.</response>
    [HttpPut("UpdateAuthor/{id}")]
    public async Task<ActionResult<Response<List<Author>>>> UpdateAuthor(AuthorUpdateDTO authorDTO)
    {
        var updatedAuthor = await _authorInterface.UpdateAuthor(authorDTO);
        return Ok(updatedAuthor);
    }
}