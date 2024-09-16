using GuiderTestTask.Data.Entities;
using GuiderTestTask.Data.Repositories;

namespace GuiderTestTask.Services;

public class EstablishmentService(IEstablishmentRepository establishmentRepository, ITagRepository tagRepository, ICategoryService categoryService) : IEstablishmentService
{
    public async Task<IEnumerable<Establishment>> GetAllAsync()
    {
        return await establishmentRepository.GetAllAsync();
    }

    public async Task<Establishment> GetEstablishmentAsync(long id)
    {
        Establishment establishment = await establishmentRepository.ReadAsync(id);
        if (establishment == null)
            throw new ApplicationException("Establishment not found");
        return establishment;
    }

    public async Task AddEstablishment(Establishment establishment)
    {
        if((await establishmentRepository.GetAllAsync()).Select(e => e.Name).Contains(establishment.Name))
            return;
        if(!(await categoryService.GetAllCategoriesAsync()).Select(c => c.Id).Contains(establishment.CategoryId))
            throw new ApplicationException($"Category '{establishment.CategoryId}' not found");
        await establishmentRepository.CreateAsync(establishment);
    }

    public async Task EditEstablishment(Establishment establishment)
    {
        if(!(await establishmentRepository.GetAllAsync()).Contains(establishment))
            return;
        await establishmentRepository.CreateAsync(establishment);
    }

    public async Task RemoveEstablishment(long establishmentId)
    {
        if((await establishmentRepository.GetAllAsync()).FirstOrDefault(e => e.Id == establishmentId) == null)
            return;
        await establishmentRepository.DeleteAsync(establishmentId);
    }

    public async Task AddEstablishmentTag(long establishmentId, Tag tag)
    {
        await GetEstablishmentAsync(establishmentId);
        if((await tagRepository.GetAllAsync()).Contains(tag))
            return;
        establishmentRepository.AddTagToEstablishment(establishmentId, tag);
    }



    public async Task RemoveEstablishmentTag(long establishmentId, Tag tag)
    {
        await GetEstablishmentAsync(establishmentId);
        if(!(await tagRepository.GetAllAsync()).Contains(tag))
            return;
        establishmentRepository.AddTagToEstablishment(establishmentId, tag);
    }
}