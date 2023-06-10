namespace KindCoins_Backend.KindCoins.Domain.Models;

public class District
{
    public int Id { get; set; }
    public string DistrictName { get; set; }
    //Relationships
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public IList<Address> Addresses { get; set; } = new List<Address>();
}