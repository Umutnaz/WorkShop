using Core;
namespace WorkShoppen.Service.Interfaces;

public interface IClothingService
{
    Task<Clothing[]> GetAllClothing();
    Task<Clothing> GetClothingById(int clothingId);
    void AddClothing(Clothing clothing);
    void UpdateClothingById(int clothingId, Clothing clothing);
    void DeleteClothingById(int clothingId);
}