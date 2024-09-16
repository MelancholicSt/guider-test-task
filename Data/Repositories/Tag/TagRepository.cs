using GuiderTestTask.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GuiderTestTask.Data.Repositories;

public class TagRepository(GuiderDbContext context) : ITagRepository
{
    public async Task<ICollection<Data.Entities.Tag>> GetAllAsync()
    {
        return context.Tags.ToList();
    }

    public async Task<Data.Entities.Tag> ReadAsync(long id)
    {
        return await context.Tags.FindAsync(id);
    }

    public async Task CreateAsync(Data.Entities.Tag tag)
    {
        await context.Tags.AddAsync(tag);
        await SaveAsync();
    }

    public async Task UpdateAsync(Data.Entities.Tag tag)
    {
        context.Entry(await ReadAsync(tag.Id)).CurrentValues.SetValues(tag);
        await SaveAsync();
    }

    public async Task DeleteAsync(long id)
    {
        context.Tags.Remove(await ReadAsync(id));
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
}