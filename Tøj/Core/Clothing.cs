using System;
namespace Core;

public class Clothing
{
    public int ClothingId { get; set; }
    public string ClothingName { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public string Type { get; set; }
    public string Size { get; set; }
    public int OwnerId { get; set; }
    public int? BorrowerId { get; set; }
    
}