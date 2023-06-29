using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Resource;

public class DepartmentResource
{
    public int Id { get; set; }
    public string DepartmentName { get; set; }
    public CountryResource Country { get; set; }
}