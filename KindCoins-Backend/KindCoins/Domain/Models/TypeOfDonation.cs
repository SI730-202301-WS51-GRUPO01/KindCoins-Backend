namespace KindCoins_Backend.KindCoins.Domain.Models;

public class TypeOfDonation
{
    public int Id {get;set;}
    public string TypeDonation {get; set;}
    //Relationships
    public IList<Campaign> Campaigns { get; set; } = new List<Campaign>();
}