using Core;
namespace WorkShoppen.Service.Interfaces;

public interface ILoginService
{
    Task<User> GetUserLoggedIn();
    Task<bool> Login(string username, string password);
    void CreateUser(User user);
    int GetUserIdMax();
}