using Core;
namespace ServerAPI.Repository.Interfaces;

public interface IClothingRepository
{
    Task<Clothing[]> GetAllClothing();
    void AddClothing(Clothing clothing);
    void DeleteClothingById(int clothingId);
    Task<Clothing[]> GetClothingByOwnerId(int ownerId);
    Task<Clothing> GetClothingById(int clothingId);
    void UpdateClothingById(int clothingId, Clothing updatedClothing);
}