using AutoMapper;
using Demo2.Entity;
using Demo2.Interfaces;
using Demo2.Models.RequestModel;
using Demo2.Models.ResponseModel;
using Demo2.Service;
using Microsoft.AspNetCore.Mvc;

namespace Demo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryService.GetCategories();
            if (!result.Any())
                return NotFound();

            return Ok(_mapper.Map<List<CategoryResponse>>(result));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateRequest categoryCreated)
        {
            if (categoryCreated == null)
                return BadRequest(ModelState);

            if (_categoryService.CreateCategory(_mapper.Map<Category>(categoryCreated)).Equals(null))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok("Successfully Added");
        }
        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] CategoryUpdateRequest categoryUpdated)
        {
            if (categoryUpdated == null)
                return BadRequest(ModelState);

            if (!_categoryService.CategoriesExists(categoryId))
                return NotFound();

            try
            {
                // Get the existing category entity
                Category existingCategory = await _categoryService.GetCategoryById(categoryId);

                // Update the name field based on the request body
                existingCategory.Name = categoryUpdated.Name;

                await _categoryService.UpdateCategory(existingCategory);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            if (!_categoryService.CategoriesExists(categoryId))
                 return NotFound();

            var categoryToDelete = await _categoryService.GetCategoryById(categoryId);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_categoryService.DeleteCategory(categoryToDelete).Equals(null))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
            }

            return NoContent();
        }

    }
}
