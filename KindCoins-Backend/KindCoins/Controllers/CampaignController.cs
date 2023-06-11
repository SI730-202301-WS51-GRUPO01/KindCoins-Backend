using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Resource;
using Microsoft.AspNetCore.Mvc;

namespace KindCoins_Backend.KindCoins.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CampaignController : ControllerBase
{
    private readonly ICampaignService _campaignService;
    private readonly IMapper _mapper;

    public CampaignController(ICampaignService campaignService,
        IMapper mapper)
    {
        _campaignService = campaignService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<SaveCampaignResource>> GetAllAsync()
    {
        var campaigns = await _campaignService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Campaign>,
            IEnumerable<SaveCampaignResource>>(campaigns);
        return resources;
    }
}