using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.DTOs;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Services;

public class BookService
{
     private EducationContext _context;

    public BookService(EducationContext context)
    {
        context = _context;
    }
    
    public async Task<Book?> AddBook(BookDTO book)
    {
        Book nbook = new Book
        {
            Name = book.Name,
            Price = book.Price,
            Genre = book.Genre,
            
        };
        if (book.Authors.Any())
        {
            nbook.Authors  = _context.Authors.ToList().IntersectBy(book.Authors, book => book.Id).ToList();
        }
        var result = _context.Books.Add(nbook);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<List<Book>>  GetBooks()
    {
        var result = await _context.Books.Include(a=>a.Authors).ToListAsync();;
        return await Task.FromResult(result);
    }
    public async Task<Book?> GetBook(int id)
    {
        var result = _context.Books.Include(a=>a.Authors).FirstOrDefault(book => book.Id==id);
        return await Task.FromResult(result);
    }

    public async Task<Book> GetBooksIncomplete()
    {
        var result = DataSource.GetInstance()._books;
        return result[1];
    }

    public async Task<Book?> UpdateBook(int id, Book updatedBook)
    {
        var book = await _context.Books.Include(b=>b.Authors).FirstOrDefaultAsync(au => au.Id == id);
        if (book != null)
        {
            book.Name = updatedBook.Name;
            book.Genre = updatedBook.Genre;
            book.Price = updatedBook.Price;
            book.Authors = updatedBook.Authors;
            book.Orders = updatedBook.Orders;
            
            
            if (updatedBook.Authors.Any())
            {
                book.Authors  = _context.Authors.ToList().IntersectBy(updatedBook.Authors, book => book).ToList();
            }
            _context.Books.Update(book);
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return book;
        }

        return null;

    }
    public async Task<bool> DeleteBook(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(au => au.Id == id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;

    }
}

