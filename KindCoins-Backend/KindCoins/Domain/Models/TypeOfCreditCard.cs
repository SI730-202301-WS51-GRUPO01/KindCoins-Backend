using System.Text.Json.Serialization;

namespace KindCoins_Backend.KindCoins.Domain.Models;

public class TypeOfCreditCard
{
    public int Id { get; set; }
    public string Name { get; set; }
    //Relationships
    [JsonIgnore]
    public IList<PaymentData> Comments { get; set; } = new List<PaymentData>();
}