namespace KindCoins_Backend.KindCoins.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DNI { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    //Relationships
    public IList<Post> Posts { get; set; } = new List<Post>();
    public IList<Comment> Comments { get; set; } = new List<Comment>();
    public IList<Campaign> Campaigns { get; set; } = new List<Campaign>();
    public IList<Donation> Donations { get; set; } = new List<Donation>();
    public IList<PaymentData> PaymentDatas { get; set; } = new List<PaymentData>();
}