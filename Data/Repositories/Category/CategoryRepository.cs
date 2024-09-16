using GuiderTestTask.Data.Context;
using GuiderTestTask.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuiderTestTask.Data.Repositories;

public class CategoryRepository(GuiderDbContext context) : ICategoryRepository
{
    public async Task<Category?> ReadCategoryByNameAsync(string name)
    {
        return await context.Categories.FirstOrDefaultAsync(category => category.Name == name);
    }

    public async Task CreateAsync(Category entity)
    {
        
        await context.Categories.AddAsync(entity);
        await SaveAsync();
    }

    public async Task<Category?> ReadAsync(long id)
    {
        Category? category = await context.Categories
            .Include(entity => entity.Establishments)
            .FirstOrDefaultAsync(entity => entity.Id == id);
        return category;
    }

    public async Task UpdateAsync(Category entity)
    {
        Category? category = await ReadAsync(entity.Id);
        context.Entry(entity).State = EntityState.Modified;
        await SaveAsync();
    }

    public async Task DeleteAsync(long id)
    {
        context.Categories.Remove(await ReadAsync(id));
        await SaveAsync();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return context.Categories.AsEnumerable();
    }

    public async Task AddEstablishmentToCategory(long categoryId, Establishment establishment)
    {
        Category category = await ReadAsync(categoryId);
        category.Establishments.Add(establishment);
        await SaveAsync();
    }

    public async Task RemoveEstablishmentFromCategory(long categoryId, Establishment establishment)
    {
        Category category = await ReadAsync(categoryId);
        category.Establishments.Remove(establishment);
        await SaveAsync();
    }
    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
}