using GuiderTestTask.Data.Entities;
using GuiderTestTask.Data.Repositories;

namespace GuiderTestTask.Services;

public class TagService(ITagRepository tagRepository) : ITagService
{
    public async Task<IEnumerable<Tag>> GetAllTagsAsync()
    {
        return await tagRepository.GetAllAsync();
    }

    public async Task<Tag> GetTagAsync(long id)
    {
        Tag? tag = await tagRepository.ReadAsync(id);
        if (tag == null)
            throw new ApplicationException("Tag not found");
        return tag;
    }

    public async Task AddTagAsync(Tag tag)
    {
        if((await tagRepository.GetAllAsync()).Contains(tag))
            return;
        await tagRepository.CreateAsync(tag);
    }

    public async Task RemoveTagAsync(long id)
    {
        Tag? tag = await tagRepository.ReadAsync(id);
        if(tag == null)
            return;
        await tagRepository.DeleteAsync(id);
    }

    public async Task EditTag(Tag tag)
    {
        // Invoking Service tag to check for null
        tagRepository.UpdateAsync(await GetTagAsync(tag.Id));
    }
}