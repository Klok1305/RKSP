namespace BlazorApp1.Data.Models;

public class Shop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int cost2display { get; set; }
    public IEnumerable<Author> Authors { get; set; }
}