using WorkShoppen.Service.Interfaces;
using Core;
using Blazored.LocalStorage;

namespace WorkShoppen.Service;

public class LoginServiceClientside : ILoginService
{

    private List<User> users = new List<User>()
    {
        new User()
        {
            UserId = 1, Username = "Tiffany", Password = "Tiff123", Email = "whatever@gmail.com", Role = "admin",
            PhoneNumber = 125235
        },
        new User()
        {
            UserId = 2, Username = "Beth", Password = "Kittens", Email = "b@hotmail.com", Role = "user",
            PhoneNumber = 41424
        },
        new User()
        {
            UserId = 3, Username = "Camilla", Password = "123", Role = "user", Email = "c@hotmail.com",
            PhoneNumber = 41425
        }
    };
    
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
        if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
        {
            // Check om username og password combination eksisterer
            // I såfal, log bruger ind
            if (users.Any(x => x.Username == username && x.Password == password))
            {
                User user = new User() { Username = username, Password = password };
                
                await localStorage.SetItemAsync("user", user);
                return true;
            }
           
            Console.WriteLine("Username or password is incorrect");
            return false;
        }

        return false;
    }

    public void CreateUser(User user)
    {
        users.Add(user);
    }

    public int GetUserIdMax()
    {
        return users.Max(x => x.UserId);
    }
}