

public class Order
{
    public int Id { get; set; }
    public string goods { get; set; }
    public int cost { get; set; }
    public IEnumerable<Book> Books { get; set; }
    public IEnumerable<Shop> Shops { get; set; }
    public IEnumerable<User> Users { get; set; }
}