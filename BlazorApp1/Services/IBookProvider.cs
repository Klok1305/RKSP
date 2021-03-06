namespace BlazorApp1.Services;

public interface IBookProvider
{
    Task<List<Book>> GetAll();
    Task<Book> GetOne(int id);
    Task<bool> Add(Book item);
    Task<Book> Edit(Book item);
    Task<bool> Remove(int id);
}