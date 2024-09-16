using GuiderTestTask.Data.Entities;

namespace GuiderTestTask.Data.Repositories;

public interface ITagRepository
{
    Task<ICollection<Tag>> GetAllAsync();
    Task<Tag> ReadAsync(long id);
    Task CreateAsync(Tag tag);
    Task UpdateAsync(Tag tag);
    Task DeleteAsync(long id);
    Task SaveAsync();
}