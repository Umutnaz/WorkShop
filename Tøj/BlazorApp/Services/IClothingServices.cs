using Core;

namespace Tøj.Services;

public interface IBikeService
{
    Task<BEBike[]> GetAll();
    Task Add(BEBike bike);
    Task DeleteById(int id);
}