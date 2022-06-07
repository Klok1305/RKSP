using System.Net.Http.Json;
using Newtonsoft.Json;

namespace BlazorApp1.Services;

public class OrdersProvider: IOrderProvider
{
    private HttpClient _client;
    public OrdersProvider(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<List<Order>> GetAll()
    {
        return await _client.GetFromJsonAsync<List<Order>>("/api/order");
    }

    public async Task<Order> GetOne(int id)
    {
        return await _client.GetFromJsonAsync<Order>($"/api/order/{id}");
    }

    public async Task<bool> Add(Order item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PostAsync($"/api/order", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<Order> Edit(Order item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PutAsync($"/api/order", httpContent);
        Order order = JsonConvert.DeserializeObject<Order>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(order);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _client.DeleteAsync($"/api/order/${id}");

        return await Task.FromResult(delete.IsSuccessStatusCode);
    }

}