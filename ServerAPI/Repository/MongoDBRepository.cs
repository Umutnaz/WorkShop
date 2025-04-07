using ServerAPI.Repository.Interfaces;
using Core;
using MongoDB.Driver;

namespace ServerAPI.Repository;

public class MongoDBRepository : IClothingRepository
{
    MongoClient _client;
    private string connectionString = "mongodb+srv://mortenstnielsen:hlEgCKJrN89edDQt@clusterfree.a2y2b.mongodb.net/";

    public MongoDBRepository()
    {
        _client = new MongoClient(connectionString);
    }
    
    public async Task<Clothing[]> GetAllClothing()
    {
        var database = _client.GetDatabase("Clothingdb");
        var collection = database.GetCollection<Clothing>("clothing");
        
        var filter = Builders<Clothing>.Filter.Empty;
        
        var cursor = await collection.FindAsync(filter);
        var results = await cursor.ToListAsync();
        
        return results.ToArray();
    }

    public async void AddClothing(Clothing clothing)
    {
        var database = _client.GetDatabase("Clothingdb");
        var collection = database.GetCollection<Clothing>("clothing");
        
        await collection.InsertOneAsync(clothing);
    }

    public async void DeleteClothingById(int clothingId)
    {
        var database = _client.GetDatabase("Clothingdb");
        var collection = database.GetCollection<Clothing>("clothing");
        
        var filter = Builders<Clothing>.Filter.Eq("ClothingId", clothingId);
        
        await collection.DeleteOneAsync(filter);
    }

    public async Task<Clothing[]> GetClothingByOwnerId(int ownerId)
    {
        var database = _client.GetDatabase("Clothingdb");
        var collection = database.GetCollection<Clothing>("clothing");
        
        var filter = Builders<Clothing>.Filter.Eq("OwnerId", ownerId);
        var cursor = await collection.FindAsync(filter);
        var results = await cursor.ToListAsync();
        return results.ToArray();
    }

    public async Task<Clothing> GetClothingById(int clothingId)
    {
        var database = _client.GetDatabase("Clothingdb");
        var collection = database.GetCollection<Clothing>("clothing");
        
        var filter = Builders<Clothing>.Filter.Eq("ClothingId", clothingId);
        
        var result = await collection.FindAsync(filter);
        return result.FirstOrDefault();
    }

    public void UpdateClothingById(int clothingId, Clothing updatedClothing)
    {
        var database = _client.GetDatabase("Clothingdb");
        var collection = database.GetCollection<Clothing>("clothing");
        
        var filter = Builders<Clothing>.Filter.Eq("ClothingId", clothingId);
        collection.ReplaceOne(filter, updatedClothing);
    }
    
}