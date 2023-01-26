using MyToDoWebApi.Model.Dtos;
namespace MyToDoWebApi.Service.ToDoService;
public interface IToDoService
{
    Task<IEnumerable<ToDoDto.ToDoDtoResponse>> GetAll();
    Task<ToDoDto.ToDoDtoResponse> GetById(int id);
    Task AddToDo(ToDoDto.ToDoDtoRequest addToDo);
    Task UpdateToDo(int id, ToDoDto.ToDoDtoRequest addToDo);
    Task DeleteById(int id);
}