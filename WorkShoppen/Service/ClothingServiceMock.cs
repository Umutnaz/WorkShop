using Core;
using WorkShoppen.Service.Interfaces;

namespace WorkShoppen.Service;

public class ClothingServiceMock : IClothingService
{
    private List<Clothing> _clothing = new List<Clothing>()
    {
        new Clothing()
        {
            ClothingId = 1, Name = "Cute black boots", Type = "Boots", Color = "Black",
            Description = "Very nace, barely used", Size = "38", OwnerId = 3, Image = ""
        },
        new Clothing()
        {
            ClothingId = 2, Name = "Zara dress", Type = "Dress", Color = "Red",
            Description = "Super hot, small holes but it doesn't matter", Size = "M", OwnerId = 2, Image = "",
            LoanerId = 3
        },
        new Clothing()
        {
            ClothingId = 3, Name = "Timberlands", Type = "Sneakers", Color = "Light Brown",
            Description = "Boyfriends Timbs", Size = "42", OwnerId = 1, Image = "", LoanerId = 3
        }
    };


    public async Task<Clothing[]> GetAllClothing()
    {
        return _clothing.ToArray();
    }

    public async Task<Clothing> GetClothingById(int clothingId)
    {
        return _clothing.FirstOrDefault(c => c.ClothingId == clothingId);
    }

    public void AddClothing(Clothing clothing)
    {
        _clothing.Add(clothing);
    }

    public void DeleteClothingById(int clothingId)
    {
        _clothing.RemoveAll(c => c.ClothingId == clothingId);
    }

    public void UpdateClothingById(int clothingId, Clothing clothing)
    {
        _clothing.RemoveAll(c => c.ClothingId == clothingId);
        _clothing.Add(clothing);
    }
}