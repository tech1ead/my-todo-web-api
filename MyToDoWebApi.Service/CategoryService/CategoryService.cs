using MyToDoWebApi.Database.Models;
using MyToDoWebApi.Model.Dtos;
using MyToDoWebApi.Repository.UnitOfWork;
namespace MyToDoWebApi.Service.CategoryService;
public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task AddCategory(CategoryDto.CategoryDtoRequest categoryDto)
    {
        Category category = new Category
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description,
        };
        await _unitOfWork.CategoryRepository.AddAsync(category);
        await _unitOfWork.SaveAsync();
    }
    public async Task DeleteById(int id)
    {
        Category? category = await _unitOfWork.CategoryRepository.GetAsync(x => x.ID == id);
        if (category == null)
        {
            throw new ArgumentException($"Could not find Category with ID {id}");
        }
        _unitOfWork.CategoryRepository.Remove(category);
        await _unitOfWork.SaveAsync();
    }
    public async Task<IEnumerable<CategoryDto.CategoryDtoResponse>> GetAll()
    {
        IEnumerable<Category> category = await _unitOfWork.CategoryRepository.GetAllAsync();
        return category.Select(x => new CategoryDto.CategoryDtoResponse
        {
            ID = x.ID,
            Description = x.Description,
            Name = x.Name,
        }).ToList();
    }
    public async Task<CategoryDto.CategoryDtoResponse> GetById(int id)
    {
        Category? category = await _unitOfWork.CategoryRepository.GetAsync(x => x.ID == id);
        if (category == null)
        {
            throw new ApplicationException($"Couldn't find Category with ID {id}");
        }
        return new CategoryDto.CategoryDtoResponse
        {
            ID = category.ID,
            Description = category.Description,
            Name = category.Name,
        };
    }
    public async Task UpdateCategory(int id, CategoryDto.CategoryDtoRequest categoryDto)
    {
        Category? category = await _unitOfWork.CategoryRepository.GetAsync(x => x.ID == id);
        if (category == null)
        {
            throw new ApplicationException($"Couldn't find Category with ID {id}");
        }
        category.Description = categoryDto.Description;
        category.Name = categoryDto.Name;
        _unitOfWork.CategoryRepository.Update(category);
        await _unitOfWork.SaveAsync();
    }
}