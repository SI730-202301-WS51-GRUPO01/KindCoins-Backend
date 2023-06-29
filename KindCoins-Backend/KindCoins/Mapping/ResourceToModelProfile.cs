﻿using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Resource;

namespace KindCoins_Backend.KindCoins.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCampaignResource, Campaign>();
        CreateMap<SaveUserResource, User>();
        CreateMap<SaveTypeOfDonationResource, TypeOfDonation>();
        CreateMap<SaveSuscriptionPlanResource, SuscriptionPlan>();
        CreateMap<SaveAddressResource, Address>();
        CreateMap<CountryResource, Country>();
        CreateMap<DepartmentResource, Department>();
        CreateMap<DistrictResource, District>();
    }
}