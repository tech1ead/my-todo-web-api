using MyToDoWebApi.Model.Dtos;
namespace MyToDoWebApi.Service.CategoryService;
public interface ICategoryService
{
    Task<IEnumerable<CategoryDto.CategoryDtoResponse>> GetAll();
    Task<CategoryDto.CategoryDtoResponse> GetById(int id);
    Task AddCategory(CategoryDto.CategoryDtoRequest categoryDto);
    Task UpdateCategory(int id, CategoryDto.CategoryDtoRequest categoryDto);
    Task DeleteById(int id);
}