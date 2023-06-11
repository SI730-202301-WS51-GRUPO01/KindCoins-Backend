namespace KindCoins_Backend.KindCoins.Domain.Models;

public class SuscriptionPlan
{
    public int Id { get; set; }
    public string Plan { get; set; }
    //Relationships
    public IList<Campaign> Campaigns { get; set; } = new List<Campaign>();
}