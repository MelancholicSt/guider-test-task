using GuiderTestTask.Data.Entities;

namespace GuiderTestTask.Data.Repositories;

public interface IEstablishmentRepository
{
    Task<IEnumerable<Establishment>> GetAllAsync();
    Task AddTagToEstablishment(long establishmentId, Tag tag);
    Task RemoveTagFromEstablishment(long establishmentId, Tag tag);
    Task CreateAsync(Establishment entity);
    Task<Establishment?> ReadAsync(long id);
    Task UpdateAsync(Establishment entity);
    Task DeleteAsync(long id);
    Task SaveAsync();
}