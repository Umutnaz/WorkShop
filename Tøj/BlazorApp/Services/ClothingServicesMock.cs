using Core;

namespace Tøj.Services;

public class ClothingServicesMock : IClothingServices
{
    private List<Clothing> Clothings = new();
    
    public async Task<Clothing[]> GetAll()
    {
        return Clothings.ToArray();
    }

    public async Task Add(Clothing Clothing)
    {
        int max = 0;
        if (Clothings.Count > 0)
            max = Clothings.Select(b => b.ClothingId).Max();
        Clothing.ClothingId = max + 1;
        Clothings.Add(Clothing);
    }

    public async Task DeleteById(int id)
    {
        Clothings.RemoveAll(Clothing => Clothing.ClothingId == id);
    }
}