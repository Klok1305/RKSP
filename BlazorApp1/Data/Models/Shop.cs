
public class Shop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public IEnumerable<Book> Books { get; set; }
    public IEnumerable<Order> Orders { get; set; }
}