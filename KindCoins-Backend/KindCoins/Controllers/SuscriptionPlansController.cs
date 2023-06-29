using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Resource;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KindCoins_Backend.KindCoins.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class SuscriptionPlansController : ControllerBase
{
    private readonly ISuscriptionPlanService _suscriptionPlanService;
    private readonly IMapper _mapper;
    
    public SuscriptionPlansController(ISuscriptionPlanService suscriptionPlanService, IMapper mapper)
    {
        _suscriptionPlanService = suscriptionPlanService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<SuscriptionPlanResource>> GetAllAsync()
    {
        var suscriptionPlans = await _suscriptionPlanService.ListAsync();
        var resources = _mapper.Map<IEnumerable<SuscriptionPlan>,
            IEnumerable<SuscriptionPlanResource>>(suscriptionPlans);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveSuscriptionPlanResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var suscriptionPlan = _mapper.Map<SaveSuscriptionPlanResource, SuscriptionPlan>(resource);
        var result = await _suscriptionPlanService.SaveAsync(suscriptionPlan);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var suscriptionPlanResource = _mapper.Map<SuscriptionPlan, SuscriptionPlanResource>(result.Resource);
        return Ok(suscriptionPlanResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSuscriptionPlanResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var suscriptionPlan = _mapper.Map<SaveSuscriptionPlanResource, SuscriptionPlan>(resource);
        var result = await _suscriptionPlanService.UpdateAsync(id, suscriptionPlan);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var suscriptionPlanResource = _mapper.Map<SuscriptionPlan, SuscriptionPlanResource>(result.Resource);
        return Ok(suscriptionPlanResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _suscriptionPlanService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var suscriptionPlanResource = _mapper.Map<SuscriptionPlan, SuscriptionPlanResource>(result.Resource);
        return Ok(suscriptionPlanResource);
    }
}