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

    [HttpGet("ListAuthors")]
    public async Task<ActionResult<Response<List<Author>>>> ListAuthors()
    {
        var authors = await _authorInterface.ListAuthors();
        return Ok(authors);
    }

    [HttpGet("GetAuthorById/{id}")]
    public async Task<ActionResult<Response<Author>>> GetAuthorById(int id)
    {
        var author = await _authorInterface.GetAuthorById(id);
        return Ok(author);
    }

    [HttpGet("GetAuthorByBookId/{bookId}")]
    public async Task<ActionResult<Response<Author>>> GetAuthorByBook(int bookId)
    {
        var author = await _authorInterface.GetAuthorByBookId(bookId);
        return Ok(author);
    }

    [HttpPost("CreateAuthor")]
    public async Task<ActionResult<Response<List<Author>>>> CreateAuthor(AuthorCreateDTO authorDTO)
    {
        var authors = await _authorInterface.CreateAuthor(authorDTO);
        return Ok(authors);
    }

    [HttpDelete("RemoveAuthor/{id}")]
    public async Task<ActionResult<Response<List<Author>>>> RemoveAuthor(int id)
    {
        var result = await _authorInterface.RemoveAuthor(id);
        return Ok(result);
    }

    [HttpPut("UpdateAuthor/{id}")]
    public async Task<ActionResult<Response<List<Author>>>> UpdateAuthor(AuthorUpdateDTO authorDTO)
    {
        var updatedAuthor = await _authorInterface.UpdateAuthor(authorDTO);
        return Ok(updatedAuthor);
    }
}