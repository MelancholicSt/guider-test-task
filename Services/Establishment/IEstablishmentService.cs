using GuiderTestTask.Data.Entities;

namespace GuiderTestTask.Services;

public interface IEstablishmentService
{
    Task<IEnumerable<Establishment>> GetAllAsync();
    Task<Establishment> GetEstablishmentAsync(long id);
    Task AddEstablishment(Establishment establishment);
    Task EditEstablishment(Establishment establishment);
    Task RemoveEstablishment(long establishmentId);
    Task AddEstablishmentTag(long establishmentId, Tag tag);
    Task RemoveEstablishmentTag(long establishmentId,  Tag tag);
}