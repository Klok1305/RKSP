

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public IEnumerable<Book> Books { get; set; }
}

