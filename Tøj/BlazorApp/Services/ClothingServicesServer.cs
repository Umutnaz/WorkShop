using System.Net.Http.Json;
using Core;

namespace Tøj.Services;

public class ClothingServicesServer : IClothingServices
{
    private string serverUrl = "http://localhost:5284";

    private HttpClient client;
    
    public ClothingServicesServer(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Clothing[]> GetAll()
    {
        return await client.GetFromJsonAsync<Clothing[]>($"{serverUrl}/api/Clothing");
    }

    public async Task Add(Clothing Clothing)
    {
        await client.PostAsJsonAsync<Clothing>($"{serverUrl}/api/Clothing", Clothing);
    }

    public async Task DeleteById(int id)
    {
        await client.DeleteAsync($"{serverUrl}/api/Clothing/{id}");
    }
}