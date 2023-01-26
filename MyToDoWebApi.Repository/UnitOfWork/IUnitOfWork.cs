using MyToDoWebApi.Repository.CategoryRepository;
using MyToDoWebApi.Repository.ToDoRepository;
namespace MyToDoWebApi.Repository.UnitOfWork;
public interface IUnitOfWork
{
    IToDoRepository ToDoRepository { get; set; }
    ICategoryRepository CategoryRepository { get; set; }
    Task SaveAsync();
    Task RollbackAsync();
}