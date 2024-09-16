using GuiderTestTask.Data.Dto;
using GuiderTestTask.Data.Entities;
using GuiderTestTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuiderTestTask.Controllers;

[ApiController]
[Route("/establishments")]
public class EstablishmentsController(IEstablishmentService establishmentService) : ControllerBase
{
    [HttpGet("all")]
    public async Task<List<EstablishmentDto>> GetAllEstablishments()
    {
        try
        {
            IEnumerable<Establishment> establishments = await establishmentService.GetAllAsync();
            return establishments.Select(establishment => new EstablishmentDto
                                                    (
                                                        establishment.Name,
                                                        establishment.CategoryId,
                                                        establishment.Address,
                                                        establishment.Tags.Select(tag => tag.Id).ToList(),
                                                        establishment.Description
                                                    )
                                        ).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("{establishmentId}")]
    public async Task<EstablishmentDto?> GetEstablishment(long establishmentId)
    {
        try
        {
            Establishment establishment = await establishmentService.GetEstablishmentAsync(establishmentId);
            return new EstablishmentDto
            (
                establishment.Name,
                establishment.CategoryId,
                establishment.Address,
                establishment.Tags.Select(tag => tag.Id).ToList(),
                establishment.Description
            );
        }
        catch (Exception e)
        {
            return null;
        }
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddEstablishment(EstablishmentDto establishmentDto)
    {
        try
        {
            Establishment establishment = new Establishment()
            {
                Name = establishmentDto.Name,
                Address = establishmentDto.Address,
                Description = establishmentDto.Description,
                CategoryId = establishmentDto.CategoryId,
                Tags = new List<Tag>()
            };
            establishmentService.AddEstablishment(establishment);
            return Ok();
        }
        catch (ApplicationException e)
        {
            return BadRequest(e.Message);
            
        }
    }

    [HttpPut("{establishmentId}/edit")]
    public async Task<IActionResult> EditEstablishment(long establishmentId, EstablishmentDto establishmentDto)
    {
        try
        {
            Establishment establishment = await establishmentService.GetEstablishmentAsync(establishmentId);
            establishment.Name = establishmentDto.Name;
            establishment.Address = establishmentDto.Address;
            establishment.Description = establishmentDto.Description;
            establishmentService.EditEstablishment(establishment);
            return Ok();
        }
        catch (ApplicationException e)
        {
            return BadRequest(e.Message);
            
        }
    }

    [HttpDelete("{establishmentId}/remove")]
    public async Task<IActionResult> RemoveEstablishment(long establishmentId)
    {
        try
        {
            establishmentService.RemoveEstablishment(establishmentId);
            return Ok();
        }
        catch (ApplicationException e)
        {
            return BadRequest(e.Message);
        }
    }
}