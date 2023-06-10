namespace KindCoins_Backend.KindCoins.Domain.Models;

public class Department
{
    public int Id { get; set; }
    public string DepartmentName { get; set; }
    //Relationships
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public IList<District> Districts { get; set; } = new List<District>();
}