using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.Services;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
[ApiController]

public class ShopController: ControllerBase
{
    private readonly ShopService _context;

    public ShopController(ShopService context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shop>>> GetShops()
    {
        return await _context.GetShops();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Shop>> GetShop(int id)
    {
        var Shop = await _context.GetShop(id);

        if (Shop == null)
        {
            return NotFound();
        }

        return Shop;
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Shop>> Putshop(int id, [FromBody] Shop shop) // !
    {
        var result = await _context.UpdateShop(id, shop);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<Book>> PostBook([FromBody]Shop shop)
    {
        var result = await _context.AddBook(shop);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShop(int id)
    {
        var author = await _context.DeleteShop(id);
        if (author)
        {
            return Ok();
        }
        return BadRequest();
    }

}