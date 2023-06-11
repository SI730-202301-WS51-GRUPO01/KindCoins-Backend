namespace KindCoins_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

public class ModelStateExtensions
{
    public static List<string> GetErrorMessages(
        ModelStateDictionary dictionary)
    {
        return dictionary.SelectMany(m => m.Value.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }

}