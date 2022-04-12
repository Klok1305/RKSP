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
}