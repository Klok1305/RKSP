using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.DTOs;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Services;

public class OrderService
{
    private EducationContext _context;

    public OrderService(EducationContext context)
    {
        context = _context;
    }
    
    public async Task<Order?> AddOrder(OrderDTO order)
    {
        Order norder = new Order
        {
            cost = order.cost,
            goods = order.goods,
        };
        if (order.users.Any())
        {
            norder.Users  = _context.Users.ToList().IntersectBy(order.users, order => order.Id).ToList();
        }
        var result = _context.Orders.Add(norder);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<List<Order>>  GetOrders()
    {
        var result = await _context.Orders.Include(a=>a.Users).ToListAsync();;
        return await Task.FromResult(result);
    }
    public async Task<Order?> GetOrder(int id)
    {
        var result = _context.Orders.Include(a=>a.Users).Include(a => a.Shops).FirstOrDefault(book => book.Id==id);
        return await Task.FromResult(result);
    }

    public async Task<Order> GetOrdersIncomplete()
    {
        var result = DataSource.GetInstance()._orders;
        return result[1];
    }

    public async Task<Order?> UpdateOrder(int id, Order updatedOrder)
    {
        var order = await _context.Orders.Include(b=>b.Users).FirstOrDefaultAsync(au => au.Id == id);
        if (order != null)
        {
            order.goods = updatedOrder.goods;
            order.cost = updatedOrder.cost;
            order.Books = updatedOrder.Books;
            order.Users = updatedOrder.Users;
            if (updatedOrder.Users.Any())
            {
                order.Users  = _context.Users.ToList().IntersectBy(updatedOrder.Users, book => book).ToList();
            }
            _context.Orders.Update(order);
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return order;
        }

        return null;

    }
    public async Task<bool> DeleteOrder(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(au => au.Id == id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;

    }
}