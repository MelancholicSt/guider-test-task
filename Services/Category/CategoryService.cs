using GuiderTestTask.Data.Entities;
using GuiderTestTask.Data.Repositories;

namespace GuiderTestTask.Services;

public class CategoryService(ICategoryRepository categoryRepository, IEstablishmentRepository establishmentRepository) : ICategoryService
{
    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetCategoryAsync(long categoryId)
    {
        Category? category = await categoryRepository.ReadAsync(categoryId);
        if (category == null)
            throw new ApplicationException("Category not found");
        
        return category;
    }

    public async Task AddCategoryAsync(Category category)
    {
        if((await categoryRepository.GetAllAsync()).Select(c => c.Name).Contains(category.Name))
            throw new ApplicationException($"Category with '{category.Name}' name already exists");
        await categoryRepository.CreateAsync(category);
    }

    public async Task RemoveCategoryAsync(long categoryId)
    {
        if((await categoryRepository.GetAllAsync()).FirstOrDefault(c => c.Id == categoryId) == null)
            throw new ApplicationException("Category not found");
        await categoryRepository.DeleteAsync(categoryId);
    }

    public async Task EditCategory(Category category)
    {
        if(!(await categoryRepository.GetAllAsync()).Contains(category))
            return;
        await categoryRepository.UpdateAsync(category);
    }

    public async Task AddCategoryEstablishmentAsync(long categoryId, Establishment establishment)
    {
        await GetCategoryAsync(categoryId);
        if ((await establishmentRepository.GetAllAsync()).Contains(establishment))
            return;
        categoryRepository.AddEstablishmentToCategory(categoryId, establishment);
    }

    public async Task RemoveCategoryEstablishmentAsync(long categoryId, Establishment establishment)
    {
        await GetCategoryAsync(categoryId);
        if (!(await establishmentRepository.GetAllAsync()).Contains(establishment))
            return;
        categoryRepository.RemoveEstablishmentFromCategory(categoryId, establishment);
    }
}