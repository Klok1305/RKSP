namespace BlazorApp1.Services;

public interface IOrderProvider
{
    Task<List<Order>> GetAll();
    Task<Order> GetOne(int id);
    Task<bool> Add(Order item);
    Task<Order> Edit(Order item);
    Task<bool> Remove(int id);
}