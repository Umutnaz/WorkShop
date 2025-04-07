using Core;
using WorkShoppen.Service.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WorkShoppen.Service
{
    public class ClothingServiceMock : IClothingService
    {
        // Liste af tøj
        private List<Clothing> _clothing = new List<Clothing>()
        {
            new Clothing()
            {
                ClothingId = 1, Name = "Cute black boots", Type = "Boots", Color = "Black",
                Description = "Very nice, barely used", Size = "38", OwnerId = 3, Image = ""
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

        // Hent alt tøj
        public async Task<Clothing[]> GetAllClothing()
        {
            return _clothing.ToArray();
        }

        // Hent tøj ved clothing ID
        public async Task<Clothing> GetClothingById(int clothingId)
        {
            return _clothing.FirstOrDefault(c => c.ClothingId == clothingId);
        }

        // Hent tøj kun ved user id
        public async Task<Clothing[]> GetClothingByUser(int userId)
        {
            return _clothing.Where(c => c.OwnerId == userId).ToArray();  // Hent kun tøj der tilhører den bruger
        }

        // Tilføj tøj for en bruger
        public void AddClothing(Clothing clothing, int userId)
        {
            // Giv tøjet et unikt ID
            int nextId = _clothing.Any() ? _clothing.Max(c => c.ClothingId) + 1 : 1;
            clothing.ClothingId = nextId;

            // Sæt den aktuelle bruger som ejer
            clothing.OwnerId = userId;

            _clothing.Add(clothing);
        }


        // Slet tøj via ID
        public void DeleteClothingById(int clothingId)
        {
            _clothing.RemoveAll(c => c.ClothingId == clothingId);
        }

        // Opdater tøj ved ID
        public void UpdateClothingById(int clothingId, Clothing updatedClothing)
        {
            var clothing = _clothing.FirstOrDefault(c => c.ClothingId == clothingId);
            if (clothing != null)
            {
                clothing.Name = updatedClothing.Name;
                clothing.Description = updatedClothing.Description;
                clothing.Type = updatedClothing.Type;
                clothing.Color = updatedClothing.Color;
                clothing.Size = updatedClothing.Size;
                clothing.OwnerId = updatedClothing.OwnerId;

                if (updatedClothing.LoanerId == null)
                {
                    clothing.LoanerId = null;  // Tøjet er blevet returneret
                }
                else
                {
                    clothing.LoanerId = updatedClothing.LoanerId;  // Opdater låneren
                }
            }
        }
        
        // Returner tøj (fjern låneren)
        public void ReturnClothing(int currentUserUserId, int clothingId)
        {
            var clothing = _clothing.FirstOrDefault(c => c.ClothingId == clothingId);
            if (clothing != null)
            {
                clothing.LoanerId = null;
            }
        }

        public void resetLoanId(int loanId)
        {
            throw new NotImplementedException();
        }
    }
}
