using MyToDoWebApi.Database.Context;
using MyToDoWebApi.Database.Models;
using MyToDoWebApi.Repository.GenericRepository;
namespace MyToDoWebApi.Repository.CategoryRepository;
public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ToDoContext dbContext) : base(dbContext)
    {
    }
}