namespace KindCoins_Backend.KindCoins.Domain.Models;

public class Donation
{
    public int Id { get; set; }
    public int QuantityDonation { get; set; }
    //Relationships
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int PaymentDataId { get; set; }
    public PaymentData PaymentData { get; set; }
}