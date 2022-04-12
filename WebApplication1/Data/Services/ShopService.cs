using WebApplication1.Data.Models;

namespace WebApplication1.Data.Services;

public class ShopService
{
    public async Task<Shop> AddBook(Shop shop)
    {
        DataSource.GetInstance()._shops.Add(shop);
        return await Task.FromResult(shop);
    }
    
    public async Task<Shop> GetShop(int id)
    {
        var result = DataSource.GetInstance()._shops.Find(a => a.Id == id);
        return await Task.FromResult(result);
    }
    
    public async Task<List<Shop>> GetShops()
    {
        return await Task.FromResult(DataSource.GetInstance()._shops);
    }
    
    public async Task<Shop?> UpdateShop(int id, Shop newShop) // !
    {
        var Shop = DataSource.GetInstance()._shops.FirstOrDefault(au => au.Id == newShop.Id);
        if (Shop != null)
        {
            Shop.Name = newShop.Name;
            Shop.cost2display = newShop.cost2display;
            return Shop;
        }
        return null;
    }
    public async Task<bool> DeleteShop(int id)
    {
        var shop =  DataSource.GetInstance()._shops.FirstOrDefault(a => a.Id == id);
        if (shop != null)
        {
            DataSource.GetInstance()._shops.Remove(shop);
            return true;
        }
        return false;
    }
}