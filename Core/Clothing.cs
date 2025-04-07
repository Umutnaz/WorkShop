using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Core;

public class Clothing
{
    [BsonId]
    public int ClothingId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Type { get; set; }
    public string Image { get; set; } = "";
    [Required]
    public string Color { get; set; }
    [Required]
    public string Size { get; set; }
    // Foreign key til ejeren af tøjet
    public int OwnerId { get; set; }
    // Foreign key til personen der låner tøjet. Kan være null
    public int? LoanerId { get; set; }
}
