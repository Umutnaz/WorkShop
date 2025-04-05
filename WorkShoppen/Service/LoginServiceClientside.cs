using WorkShoppen.Service.Interfaces;
using Core;
using Blazored.LocalStorage;

namespace WorkShoppen.Service;

public class LoginServiceClientside : ILoginService
{
    private ILocalStorageService localStorage {get;set;}

    public LoginServiceClientside(ILocalStorageService localStorage)
    {
        this.localStorage = localStorage;
    }

    public async Task<User?> GetUserLoggedIn()
    {
        var res = await localStorage.GetItemAsync<User>("user");
        return res;
    }

    public async Task<bool> Login(string username, string password)
    {
        if (username.Equals("peter") && password.Equals("123"))
        {
            User user = new User() { Name = username, Password = password };
            
            await localStorage.SetItemAsync("user", user);
            return true;
        }

        return false;
    }
}