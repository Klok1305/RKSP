namespace BlazorApp1.Data.Models;

public class Book
{
    public int Id { get; set; }
    public string Author { get; set; }
    public IEnumerable<Author> Authors { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}