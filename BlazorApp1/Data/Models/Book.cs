

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Genre { get; set; }
    public IEnumerable<Order> Orders { get; set; }
    public IEnumerable<Shop> Shops { get; set; }
    public IEnumerable<Author> Authors { get; set; }
}