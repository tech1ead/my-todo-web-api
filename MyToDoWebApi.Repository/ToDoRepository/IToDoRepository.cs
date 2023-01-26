using MyToDoWebApi.Database.Models;
using MyToDoWebApi.Repository.GenericRepository;
namespace MyToDoWebApi.Repository.ToDoRepository;
public interface IToDoRepository : IGenericRepository<ToDo>
{
}