using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyToDoWebApi.Model.Dtos;
using MyToDoWebApi.Service.CategoryService;
using MyToDoWebApi.Service.ToDoService;

namespace MyToDoWebAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryService.GetAll());
        }
        [HttpGet("single")]
        public async Task<IActionResult> GetCategoryById([FromQuery] int categoryId)
        {
            return Ok(await _categoryService.GetById(categoryId));
        }
        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveCategory([FromQuery] int categoryId)
        {
            await _categoryService.DeleteById(categoryId);
            return NoContent();
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto.CategoryDtoRequest categoryDto)
        {
            await _categoryService.AddCategory(categoryDto);
            return Ok();
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategory([FromQuery] int categoryId, [FromBody] CategoryDto.CategoryDtoRequest categoryDto)
        {
            await _categoryService.UpdateCategory(categoryId, categoryDto);
            return Ok();
        }
    }
}
