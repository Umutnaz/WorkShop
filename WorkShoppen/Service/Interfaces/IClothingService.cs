using Core;
using System.Threading.Tasks;

namespace WorkShoppen.Service.Interfaces
{
    public interface IClothingService
    {
        Task<Clothing[]> GetAllClothing(); // Hent alt tøj
        Task<Clothing> GetClothingById(int clothingId); // Hent tøj via ID
        Task<Clothing[]> GetClothingByUser(int userId); // Hent tøj for en specifik bruger
        void AddClothing(Clothing clothing, int userId); // Tilføj tøj til en bruger (fejl med userId?)
        void DeleteClothingById(int clothingId); // Slet tøj via ID
        void UpdateClothingById(int clothingId, Clothing updatedClothing); // Opdater tøj
        void resetLoanId(int clothingId);
    }
}