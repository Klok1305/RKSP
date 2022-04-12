using WebApplication1.Data.Models;

namespace WebApplication1.Data.Services;

public class BookService
{
    public async Task<Book> AddBook(Book book)
    {
        DataSource.GetInstance()._books.Add(book);
        return await Task.FromResult(book);
    }
    
    public async Task<Book> GetBook(int id)
    {
        var result = DataSource.GetInstance()._books.Find(a => a.Id == id);
        return await Task.FromResult(result);
    }
    
    public async Task<List<Book>> GetBooks()
    {
        return await Task.FromResult(DataSource.GetInstance()._books);
    }
    
    public async Task<Book?> UpdateBook(int id, Book newBook) // !
    {
        var book = DataSource.GetInstance()._books.FirstOrDefault(au => au.Id == newBook.Id);
        if (book != null)
        {
            book.Name = newBook.Name;
            book.Author = newBook.Author;
            book.Price = newBook.Price;
            return book;
        }
        return null;
    }
    public async Task<bool> DeleteBook(int id)
    {
        var book =  DataSource.GetInstance()._books.FirstOrDefault(a => a.Id == id);
        if (book != null)
        {
            DataSource.GetInstance()._books.Remove(book);
            return true;
        }
        return false;
    }

}

