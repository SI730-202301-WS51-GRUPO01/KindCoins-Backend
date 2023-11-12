using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Resource;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KindCoins_Backend.KindCoins.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PostController: ControllerBase
{
    private readonly IPostService _postService;
    private readonly IMapper _mapper;

    public PostController(IPostService postService, IMapper mapper)
    {
        _postService = postService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<PostResource>> GetAllAsync()
    {
        var posts = await _postService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePostResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var post = _mapper.Map<SavePostResource, Post>(resource);
        var result = await _postService.SaveAsync(post);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var postResource = _mapper.Map<Post, PostResource>(result.Resource);
        return Ok(postResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePostResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var post = _mapper.Map<SavePostResource, Post>(resource);
        var result = await _postService.UpdateAsync(id, post);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var postResource = _mapper.Map<Post, PostResource>(result.Resource);
        return Ok(postResource);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _postService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var postResource = _mapper.Map<Post, PostResource>(result.Resource);
        return Ok(postResource);
    }
}