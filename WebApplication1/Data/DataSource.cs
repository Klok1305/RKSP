using WebApplication1.Data.Models;

namespace WebApplication1.Data;

public class DataSource
{
    private static DataSource instance;
    private DataSource()
    {
    }
    public static DataSource GetInstance()
    {
        if (instance == null)
        {
            instance = new DataSource();
        }
        return instance;
    }
    public List<Book> _books = new List<Book>();
    public List<Author> _authors = new List<Author>();
    public List<Shop> _shops = new List<Shop>();
    public List<Order> _orders = new List<Order>();
    public List<User> _users = new List<User>();
}