namespace KindCoins_Backend.KindCoins.Domain.Models;

public class Post
{
    public int Id { get; set; }
    public string Comment { get; set; }
    public string Url { get; set; }
    public string Photo { get; set; }
    public int Likes { get; set; }
    public int Shares { get; set; }
    
    //Relationships
    
    public int UserId { get; set; }
    public User User { get; set; }
    public IList<Comment> Comments { get; set; } = new List<Comment>();
}