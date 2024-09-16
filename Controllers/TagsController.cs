using GuiderTestTask.Data.Dto;
using GuiderTestTask.Data.Entities;
using GuiderTestTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuiderTestTask.Controllers;

[ApiController]
[Route("/tags")]
public class TagsController(ITagService tagService) : ControllerBase
{
    [HttpGet("all")]
    public async Task<List<TagDto>> GetAllTags()
    {
        try
        {
            IEnumerable<Tag> tags = await tagService.GetAllTagsAsync();
            return tags.Select(tag => new TagDto
                (
                    tag.Name,
                    tag.Description,
                    tag.Establishments.Select(establishment => establishment.Id).ToList()
                )
            ).ToList();
        }
        catch (ApplicationException ex)
        {
            return null;
        }
    }

    [HttpGet("{tagId}")]
    public async Task<TagDto> GetTag(long tagId)
    {
        try
        {
            Tag tag = await tagService.GetTagAsync(tagId);
            return new TagDto
            (
                tag.Name,
                tag.Description,
                tag.Establishments.Select(establishment => establishment.Id).ToList()
            );
        }
        catch (ApplicationException e)
        {
            return null;
        }
    }

    [HttpPost("add")]
    public async Task AddTag()
    {
        try
        {
            
        }
    }
}