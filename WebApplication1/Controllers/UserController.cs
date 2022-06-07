using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.DTOs;
using WebApplication1.Data.Models;
using WebApplication1.Data.Services;

namespace WebApplication1.Controllers;

public class UserController: ControllerBase
{
    private readonly UserService _context;

    public UserController(UserService context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.GetUsers();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var order = await _context.GetUser(id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<User>> PutUser(int id, [FromBody] User user) // !
    {
        var result = await _context.UpdateUser(id, user);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<User>> PostUser([FromBody]UserDTO user)
    {
        var result = await _context.AddUser(user);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.DeleteUser(id);
        if (user)
        {
            return Ok();
        }
        return BadRequest();
    }
}