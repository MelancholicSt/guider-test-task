using GuiderTestTask.Data.Context;
using GuiderTestTask.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuiderTestTask.Data.Repositories;

public class EstablishmentRepository(GuiderDbContext context) : IEstablishmentRepository
{

    public async Task CreateAsync(Establishment entity)
    {
        await context.Establishments.AddAsync(entity);
        await SaveAsync();
    }

    public async Task<Establishment?> ReadAsync(long id)
    {
        Establishment establishment = await context.Establishments
            .Include(entity => entity.Tags)
            .FirstOrDefaultAsync(entity => entity.Id == id);
        return establishment;
    }

    public async Task UpdateAsync(Establishment entity)
    {
        Establishment establishment = await ReadAsync(entity.Id);
        context.Entry(establishment).CurrentValues.SetValues(entity);
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        context.Establishments.Remove(await ReadAsync(id));
        await SaveAsync();
    }

    public async Task<IEnumerable<Establishment>> GetAllAsync()
    {
        return context.Establishments.AsEnumerable();
    }

    public async Task AddTagToEstablishment(long establishmentId, Tag tag)
    {
        Establishment establishment = await ReadAsync(establishmentId);
        establishment.Tags.Add(tag);
        await SaveAsync();
    }

    public async Task RemoveTagFromEstablishment(long establishmentId, Tag tag)
    {
        Establishment establishment = await ReadAsync(establishmentId);
        establishment.Tags.Remove(tag);
        await SaveAsync();
    }
}