using WebApplication1.Data.Models;

namespace WebApplication1.Data.DTOs;

public class ShopDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int[] Books { get; set; }
    public int[] Orders { get; set; }
}