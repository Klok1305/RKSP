using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTOs;

public class AuthorDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int[] Books { get; set; }
}   