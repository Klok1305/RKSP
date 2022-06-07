namespace BlazorApp1.Services;

public interface IUserProvider
{
    Task<List<User>> GetAll();
    Task<User> GetOne(int id);
    Task<bool> Add(User item);
    Task<User> Edit(User item);
    Task<bool> Remove(int id);
}