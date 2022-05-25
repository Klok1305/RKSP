namespace BlazorApp1.Data.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public int Age { get; set; }
    public IEnumerable<Book> Books { get; set; }
    public IEnumerable<Shop> Shops { get; set; }
    public IEnumerable<Affiliation> Affiliations { get; set; }
}