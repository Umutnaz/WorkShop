using System.Net.Http.Json;
using Core;
using WorkShoppen.Service.Interfaces;

namespace WorkShoppen.Service;

public class ClothingServiceServer : IClothingService
{
    private HttpClient client;
    private string baseUrl = "http://localhost:5288/api/clothing";

    public ClothingServiceServer(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<Clothing[]?> GetAllClothing()
    {
        return await client.GetFromJsonAsync<Clothing[]?>($"{baseUrl}/getall");
    }

    public async Task<Clothing> GetClothingById(int clothingId)
    {
        return await client.GetFromJsonAsync<Clothing>($"{baseUrl}/getoneclothing/{clothingId}");
    }

    public async Task<Clothing[]?> GetClothingByUser(int userId)
    {
        return await client.GetFromJsonAsync<Clothing[]?>($"{baseUrl}/getclothingowner/{userId}");
    }

    public async void AddClothing(Clothing clothing, int userId)
    {
        clothing.OwnerId = userId;
        await client.PostAsJsonAsync($"{baseUrl}/add", clothing);
    }

    public void DeleteClothingById(int clothingId)
    {
        client.DeleteAsync($"{baseUrl}/delete/{clothingId}");
    }

    public void UpdateClothingById(int clothingId, Clothing updatedClothing)
    {
        client.PutAsJsonAsync($"{baseUrl}/update/{clothingId}", updatedClothing);
    }
}