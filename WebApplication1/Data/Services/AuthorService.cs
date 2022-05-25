using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data.DTOs;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Services;
    
public class AuthorService
{
    public async Task<Author> AddAuthor1(Author author)
    {
        DataSource.GetInstance()._authors.Add(author);
        return await Task.FromResult(author);
    }
    private EducationContext _context;
    public async Task<Author?> AddAuthor(AuthorDTO author)
    {
        Author nauthor = new Author
        {
            Name = author.Name,
            Genre = author.Genre,
            Age = author.Age
        };
        if (author.Affiliations.Any())
        {
            nauthor.Affiliations  = _context.Affiliations.ToList().IntersectBy(author.Affiliations, affiliation => affiliation.Id).ToList();
        }
        var result = _context.Authors.Add(nauthor);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<Author> GetAuthor(int id)
    {
        var result = _context.Authors.Include(a=>a.Affiliations).Include(b=>b.Books).FirstOrDefault(author => author.Id==id);
    
        return await Task.FromResult(result);

    }

    public async Task<Author> GetAuthorsIncomplete()
    {
        var result = DataSource.GetInstance()._authors;
        return result[1];
    }

    public async Task<List<Author>> GetAuthors()
    {
        var result = await _context.Authors.Include(a=>a.Affiliations).Include(b=>b.Books).ToListAsync();
        return await Task.FromResult(result);

    }
    
    public async Task<Author?> UpdateAuthor(int id, Author updatedAuthor) // !
    {
        var author = await _context.Authors.Include(author=>author.Affiliations).Include(b=>b.Books).FirstOrDefaultAsync(au => au.Id == id);
        if (author != null)
        {
            author.Name = updatedAuthor.Name;
            author.Age = updatedAuthor.Age;
            author.Genre = updatedAuthor.Genre;
            if (updatedAuthor.Affiliations.Any())
            {
                author.Affiliations  = _context.Affiliations.ToList().IntersectBy(updatedAuthor.Affiliations, affiliation => affiliation).ToList();
            }
            if (updatedAuthor.Books.Any())
            {
                author.Books  = _context.Books.ToList().IntersectBy(updatedAuthor.Books, article => article).ToList();
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