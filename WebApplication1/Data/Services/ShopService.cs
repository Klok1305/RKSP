using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.DTOs;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Services;

public class ShopService
{
    private EducationContext _context;

    public ShopService(EducationContext context)
    {
        context = _context;
    }
    
    public async Task<Shop?> AddShop(ShopDTO shop)
    {
        Shop nshop = new Shop
        {
            Name = shop.Name,
            Location = shop.Location
        };
        if (shop.Orders.Any())
        {
            nshop.Orders  = _context.Orders.ToList().IntersectBy(shop.Orders, book => book.Id).ToList();
        }
        var result = _context.Shops.Add(nshop);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<List<Shop>>  GetShops()
    {
        var result = await _context.Shops.Include(a=>a.Orders).ToListAsync();;
        return await Task.FromResult(result);
    }
    public async Task<Shop?> GetShop(int id)
    {
        var result = _context.Shops.Include(a=>a.Orders).FirstOrDefault(shop => shop.Id==id);
        return await Task.FromResult(result);
    }

    public async Task<Shop> GetShopsIncomplete()
    {
        var result = DataSource.GetInstance()._shops;
        return result[1];
    }

    public async Task<Shop?> UpdateShop(int id, Shop updatedShop) // !
    {
        var shop = await _context.Shops.Include(b=>b.Books).FirstOrDefaultAsync(au => au.Id == id);
        if (shop != null)
        {
            shop.Name = updatedShop.Name;
            shop.Location = updatedShop.Location;
            shop.Orders = updatedShop.Orders;
            shop.Books = updatedShop.Books;
            
            if (updatedShop.Books.Any())
            {
                shop.Books  = _context.Books.ToList().IntersectBy(updatedShop.Books, book => book).ToList();
            }
            _context.Shops.Update(shop);
            _context.Entry(shop).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return shop;
        }

        return null;

    }
    public async Task<bool> DeleteShop(int id)
    {
        var shop = await _context.Shops.FirstOrDefaultAsync(au => au.Id == id);
        if (shop != null)
        {
            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;

    }
}