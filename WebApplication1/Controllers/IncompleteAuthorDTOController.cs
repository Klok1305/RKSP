using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.DTOs;
using WebApplication1.Data.Models;
using WebApplication1.Data.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IncompleteAuthorDTOController: ControllerBase
{
    private readonly AuthorService _context;

    public IncompleteAuthorDTOController(AuthorService context)
    {
        _context = context;
    }
    
    [HttpGet("/incomplete")]
    public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
    {
        return await _context.GetAuthors();
    }
    [HttpGet("/incomplete_{id}")]
    public async Task<ActionResult<Author>> GetAuthor(int id)
    {
        var book = await _context.GetAuthor(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }
    [HttpPut("/incomplete_{id}")]
    public async Task<ActionResult<Author>> PutAuthor(int id, [FromBody] Author author) // !
    {
        var result = await _context.UpdateAuthor(id, author);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }
    [HttpPost("/incomplete")]
    public async Task<ActionResult<Author>> PostBook([FromBody]AuthorDTO author)
    {
        var result = await _context.AddAuthor(author);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }
    [HttpDelete("/incomplete_{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var author = await _context.DeleteAuthor(id);
        if (author)
        {
            return Ok();
        }
        return BadRequest();
    }



}