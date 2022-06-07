namespace BlazorApp1.Services;

public interface IShopProvider
{
    Task<List<Shop>> GetAll();
    Task<Shop> GetOne(int id);
    Task<bool> Add(Shop item);
    Task<Shop> Edit(Shop item);
    Task<bool> Remove(int id);
}