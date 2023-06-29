using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Resource;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KindCoins_Backend.KindCoins.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CountryController: ControllerBase
{
     private readonly ICountryService _countryService;
    private readonly IMapper _mapper;
    
    public CountryController(ICountryService countryService, IMapper mapper)
    {
        _countryService = countryService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<CountryResource>> GetAllAsync()
    {
        var countries = await _countryService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(countries);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CountryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var country = _mapper.Map<CountryResource, Country>(resource);
        var result = await _countryService.SaveAsync(country);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var countryResource = _mapper.Map<Country, CountryResource>(result.Resource);
        return Ok(countryResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] CountryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var country = _mapper.Map<CountryResource, Country>(resource);
        var result = await _countryService.UpdateAsync(id, country);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var countryResource = _mapper.Map<Country, CountryResource>(result.Resource);
        return Ok(countryResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _countryService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var countryResource = _mapper.Map<Country, CountryResource>(result.Resource);
        return Ok(countryResource);
    }
}