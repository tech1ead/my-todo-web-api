using MyToDoWebApi.Database.Models;
using MyToDoWebApi.Repository.GenericRepository;
namespace MyToDoWebApi.Repository.CategoryRepository;
public interface ICategoryRepository : IGenericRepository<Category>
{
}