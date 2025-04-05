namespace Core;

public class Clothing
{
    public int ClothingId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string Image { get; set; }
    public string Color { get; set; }
    public string Size { get; set; }
    // Foreign key til ejeren af tøjet
    public int OwnerId { get; set; }
    // Foreign key til personen der låner tøjet. Kan være null
    public int? LoanerId { get; set; }
}