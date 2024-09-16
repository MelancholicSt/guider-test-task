using GuiderTestTask.Data.Entities;

namespace GuiderTestTask.Data.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task AddEstablishmentToCategory(long categoryId, Establishment establishment);
    Task RemoveEstablishmentFromCategory(long categoryId, Establishment establishment);
    Task CreateAsync(Category entity);
    Task<Category?> ReadAsync(long id);
    Task UpdateAsync(Category entity);
    Task DeleteAsync(long id);
    Task SaveAsync();
}