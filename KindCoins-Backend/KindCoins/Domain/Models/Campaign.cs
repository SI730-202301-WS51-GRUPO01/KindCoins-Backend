namespace KindCoins_Backend.KindCoins.Domain.Models;

public class Campaign
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slogan { get; set; }
    public string HeaderPhoto { get; set; }
    public string AditionalPhoto { get; set; }
    public string Description { get; set; }

    public int Goal { get; set; }

    //Relationships
    public int UserId { get; set; }
    public User User { get; set; }
    public int TypeOfDonationId { get; set; }
    public TypeOfDonation TypeOfDonation { get; set; }

    public int PaymentDataId { get; set; }
    public PaymentData PaymentData { get; set; }
    public IList<Address> Addresses { get; set; } = new List<Address>();
    public IList<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
    public IList<Donation> Donations { get; set; } = new List<Donation>();
}