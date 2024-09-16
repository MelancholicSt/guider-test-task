using GuiderTestTask.Data.Entities;

namespace GuiderTestTask.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryAsync(long categoryId);
    Task AddCategoryAsync(Category category);
    Task RemoveCategoryAsync(long categoryId);
    Task EditCategory(Category category);
    Task AddCategoryEstablishmentAsync(long categoryId, Establishment establishment);
    Task RemoveCategoryEstablishmentAsync(long categoryId, Establishment establishment);
}