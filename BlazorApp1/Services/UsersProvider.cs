using System.Net.Http.Json;
using Newtonsoft.Json;

namespace BlazorApp1.Services;

public class UsersProvider: IUserProvider
{
    private HttpClient _client;
    public UsersProvider(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<List<User>> GetAll()
    {
        return await _client.GetFromJsonAsync<List<User>>("/api/user");
    }

    public async Task<User> GetOne(int id)
    {
        return await _client.GetFromJsonAsync<User>($"/api/user/{id}");
    }

    public async Task<bool> Add(User item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PostAsync($"/api/user", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<User> Edit(User item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PutAsync($"/api/user", httpContent);
        User user = JsonConvert.DeserializeObject<User>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(user);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _client.DeleteAsync($"/api/user/${id}");

        return await Task.FromResult(delete.IsSuccessStatusCode);
    }

}