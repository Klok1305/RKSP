using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Services;

public class AuthorService
{
    public async Task<Author> AddBook(Author author)
    {
        DataSource.GetInstance()._authors.Add(author);
        return await Task.FromResult(author);
    }
    
    public async Task<Author> GetAuthor(int id)
    {
        var result = DataSource.GetInstance()._authors.Find(a => a.Id == id);
        return await Task.FromResult(result);
    }
    
    public async Task<List<Author>> GetAuthors()
    {
        return await Task.FromResult(DataSource.GetInstance()._authors);
    }
    
    public async Task<Author?> UpdateAuthor(int id, Author newBook) // !
    {
        var auth = DataSource.GetInstance()._authors.FirstOrDefault(au => au.Id == newBook.Id);
        if (auth != null)
        {
            auth.Name = newBook.Name;
            auth.Genre = newBook.Genre;
            auth.Age = newBook.Age;
            return auth;
        }
        return null;
    }
    public async Task<bool> DeleteAuthor(int id)
    {
        var author =  DataSource.GetInstance()._authors.FirstOrDefault(a => a.Id == id);
        if (author != null)
        {
            DataSource.GetInstance()._authors.Remove(author);
            return true;
        }
        return false;
    }
}