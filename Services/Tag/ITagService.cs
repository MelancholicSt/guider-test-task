using GuiderTestTask.Data.Entities;

namespace GuiderTestTask.Services;

public interface ITagService
{
    Task<IEnumerable<Tag>> GetAllTagsAsync();
    Task<Tag> GetTagAsync(long id);
    Task AddTagAsync(Tag tag);
    Task RemoveTagAsync(long id);
    Task EditTag(Tag tag);
    
}