using MyToDoWebApi.Database.Context;
using MyToDoWebApi.Database.Models;
using MyToDoWebApi.Repository.GenericRepository;
namespace MyToDoWebApi.Repository.ToDoRepository;
public class ToDoRepository : GenericRepository<ToDo>, IToDoRepository
{
    public ToDoRepository(ToDoContext dbContext) : base(dbContext)
    {
    }
}