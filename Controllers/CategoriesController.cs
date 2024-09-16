using GuiderTestTask.Data.Dto;
using GuiderTestTask.Data.Entities;
using GuiderTestTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuiderTestTask.Controllers;

[ApiController]
[Route("/categories")]

public class CategoriesController(ICategoryService categoryService, IEstablishmentService establishmentService) : ControllerBase
{
   [HttpGet("{categoryId}")]
   public async Task<CategoryDto> GetCategory(long categoryId)
   {
      try
      {
         Category category = await categoryService.GetCategoryAsync(categoryId);
         return new CategoryDto
            (
               category.Name, 
               category.Establishments.Select(establishment => establishment.Id).ToList(),
               category.Description
            );
      }
      catch (Exception e)
      {
         Console.WriteLine(e);
         throw;
      }
   }
   [HttpGet("all")]
   public async Task<List<CategoryDto>> GetAllCategories()
   {
      try
      {
         IEnumerable<Category> categories = await categoryService.GetAllCategoriesAsync();
         return categories.Select(
            category => new CategoryDto(
               category.Name, 
               category.Establishments.Select(establishment => establishment.Id).ToList()
               , category.Description
               )
            ).ToList();
      }
      catch (Exception e)
      {
         Console.WriteLine(e);
         throw;
      }
   }
   
   [HttpPost("add")]
   public async Task<IActionResult> AddCategory(CategoryDto categoryDto)
   {
      try
      {
         Category category = new Category
         {
            Name = categoryDto.Name,
            Description = categoryDto.Description
         };
         await categoryService.AddCategoryAsync(category);
      }
      catch (ApplicationException ex)
      {
         return BadRequest(ex.Message);
      }
      
      return Ok();
   }

   [HttpPut("{categoryId}/edit")]
   public async Task<IActionResult> EditCategory(long categoryId, CategoryDto categoryDto)
   {
      try
      {
         Category category = await categoryService.GetCategoryAsync(categoryId);
         category.Name = categoryDto.Name;
         category.Description = categoryDto.Description;
         await categoryService.EditCategory(category);
      }
      catch (ApplicationException ex)
      {
         return BadRequest(ex.Message);
      }

      return Ok();
   }

   [HttpDelete("{categoryId}/remove")]
   public async Task<IActionResult> RemoveCategory(long categoryId)
   {
      try
      {
         await categoryService.RemoveCategoryAsync(categoryId);
      }
      catch (ApplicationException ex)
      {
         return BadRequest(ex.Message);
      }
      catch (Exception)
      {
         return Problem();
      }

      return Ok();
   }

   [HttpPost("{categoryId}/establishments/add/{establishmentId}")]
   public async Task<IActionResult> AddEstablishmentToCategory(long categoryId, long establishmentId)
   {
      try
      {
         Establishment establishment = await establishmentService.GetEstablishmentAsync(establishmentId);
         categoryService.AddCategoryEstablishmentAsync(categoryId, establishment);
      }
      catch (ApplicationException ex)
      {
         return BadRequest(ex.Message);
      }
      return Ok();
   }

   [HttpPost("{categoryId}/establishments/{establishmentId}/remove")]
   public async Task<IActionResult> RemoveEstablishmentFromCategory(long categoryId, long establishmentId)
   {
      try
      {
         Establishment establishment = await establishmentService.GetEstablishmentAsync(establishmentId);
         categoryService.RemoveCategoryEstablishmentAsync(categoryId, establishment);
      }
      catch (ApplicationException ex)
      {
         return BadRequest(ex.Message);
      }
      return Ok();
   }
}