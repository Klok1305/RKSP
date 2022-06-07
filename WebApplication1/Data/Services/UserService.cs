using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.DTOs;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Services;

public class UserService
{
    private EducationContext _context;

    public UserService(EducationContext context)
    {
        context = _context;
    }
    
    public async Task<User?> AddUser(UserDTO user)
    {
        User nuser = new User
        {
            Name = user.Name,
        };
        if (user.Orders.Any())
        {
            nuser.Orders  = _context.Orders.ToList().IntersectBy(user.Orders, book => book.Id).ToList();
        }
        var result = _context.Users.Add(nuser);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<List<User>>  GetUsers()
    {
        var result = await _context.Users.Include(a=>a.Orders).ToListAsync();;
        return await Task.FromResult(result);
    }
    public async Task<User?> GetUser(int id)
    {
        var result = _context.Users.Include(a=>a.Orders).FirstOrDefault(shop => shop.Id==id);
        return await Task.FromResult(result);
    }

    public async Task<User> GetUsersIncomplete()
    {
        var result = DataSource.GetInstance()._users;
        return result[1];
    }

    public async Task<User?> UpdateUser(int id, User updatedUser) // !
    {
        var user = await _context.Users.Include(b=>b.Orders).FirstOrDefaultAsync(au => au.Id == id);
        if (user != null)
        {
            user.Name = updatedUser.Name;
            user.Orders = updatedUser.Orders;

            if (updatedUser.Orders.Any())
            {
                user.Orders  = _context.Orders.ToList().IntersectBy(updatedUser.Orders, order => order).ToList();
            }
            _context.Users.Update(user);
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        return null;

    }
    public async Task<bool> DeleteUser(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(au => au.Id == id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;

    }
}