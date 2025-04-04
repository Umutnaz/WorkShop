using Core;

namespace Tøj.Services;

public interface IClothingServices
{
    Task<Clothing[]> GetAll();
    Task Add(Clothing Clothing);
    Task DeleteById(int id);
}