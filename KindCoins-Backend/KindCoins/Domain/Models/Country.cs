namespace KindCoins_Backend.KindCoins.Domain.Models;

public class Country
{
    public int Id { get; set; }
    public string CountryName { get; set; }
    //Relationships
    public IList<Department> Departments { get; set; } = new List<Department>();
}