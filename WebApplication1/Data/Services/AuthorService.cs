using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data.DTOs;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Services;
    
public class AuthorService
{
    private EducationContext _context;

    public AuthorService(EducationContext context)
    {
        context = _context;
    }
    
    public async Task<Author?> AddAuthor(AuthorDTO author)
    {
        Author nauthor = new Author
        {
            Name = author.Name,
            Age = author.Age
        };
        if (author.Books.Any())
        {
            nauthor.Books  = _context.Books.ToList().IntersectBy(author.Books, book => book.Id).ToList();
        }
        var result = _context.Authors.Add(nauthor);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<List<Author>>  GetAuthors()
    {
        var result = await _context.Authors.Include(a=>a.Books).ToListAsync();;
        return await Task.FromResult(result);
    }
    public async Task<Author?> GetAuthor(int id)
    {
        var result = _context.Authors.Include(a=>a.Books).FirstOrDefault(author => author.Id==id);
        return await Task.FromResult(result);
    }

    public async Task<Author> GetAuthorsIncomplete()
    {
        var result = DataSource.GetInstance()._authors;
        return result[1];
    }

    public async Task<Author?> UpdateAuthor(int id, Author updatedAuthor) // !
    {
        var author = await _context.Authors.Include(b=>b.Books).FirstOrDefaultAsync(au => au.Id == id);
        if (author != null)
        {
            author.Name = updatedAuthor.Name;
            author.Age = updatedAuthor.Age;
            
            if (updatedAuthor.Books.Any())
            {
                author.Books  = _context.Books.ToList().IntersectBy(updatedAuthor.Books, book => book).ToList();
            }
            _context.Authors.Update(author);
            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return author;
        }

        return null;

    }
    public async Task<bool> DeleteAuthor(int id)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(au => au.Id == id);
        if (author != null)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;

    }
}