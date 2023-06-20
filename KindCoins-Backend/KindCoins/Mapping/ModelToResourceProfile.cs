using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Resource;

namespace KindCoins_Backend.KindCoins.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, SaveUserResource>();
        CreateMap<Campaign, SaveCampaignResource>();
        
        CreateMap<TypeOfDonation, TypeOfDonationResource>();
        CreateMap<SuscriptionPlan, SuscriptionPlanResource>();
    }
}