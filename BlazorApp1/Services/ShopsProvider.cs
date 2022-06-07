using System.Net.Http.Json;
using Newtonsoft.Json;

namespace BlazorApp1.Services;

public class ShopsProvider: IShopProvider
{
    private HttpClient _client;
    public ShopsProvider(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<List<Shop>> GetAll()
    {
        return await _client.GetFromJsonAsync<List<Shop>>("/api/shop");
    }

    public async Task<Shop> GetOne(int id)
    {
        return await _client.GetFromJsonAsync<Shop>($"/api/shop/{id}");
    }

    public async Task<bool> Add(Shop item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PostAsync($"/api/shop", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<Shop> Edit(Shop item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PutAsync($"/api/shop", httpContent);
        Shop shop = JsonConvert.DeserializeObject<Shop>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(shop);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _client.DeleteAsync($"/api/shop/${id}");

        return await Task.FromResult(delete.IsSuccessStatusCode);
    }

}