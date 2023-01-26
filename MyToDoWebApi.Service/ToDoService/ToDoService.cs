using MyToDoWebApi.Database.Models;
using MyToDoWebApi.Model.Dtos;
using MyToDoWebApi.Repository.UnitOfWork;
namespace MyToDoWebApi.Service.ToDoService;
public class ToDoService : IToDoService
{
    private readonly IUnitOfWork _unitOfWork;
    public ToDoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task AddToDo(ToDoDto.ToDoDtoRequest addToDo)
    {
        ToDo todo = new ToDo
        {
            Title = addToDo.Title,
            DateAdded = DateTime.Now,
            Description = addToDo.Description,
            DueDate = (DateTime)(addToDo.DueDate != null ? addToDo.DueDate : DateTime.Now),
            IsCompleted = addToDo.IsCompleted,
            CategoryID = addToDo.CategoryID,
        };
        await _unitOfWork.ToDoRepository.AddAsync(todo);
        await _unitOfWork.SaveAsync();
    }
    public async Task DeleteById(int id)
    {
        ToDo? todo = await _unitOfWork.ToDoRepository.GetAsync(x => x.ID == id);
        if (todo == null)
        {
            throw new ArgumentException($"Could not find ToDo with ID {id}");
        }
        _unitOfWork.ToDoRepository.Remove(todo);
        await _unitOfWork.SaveAsync();
    }
    public async Task<IEnumerable<ToDoDto.ToDoDtoResponse>> GetAll()
    {
        IEnumerable<ToDo> result = await _unitOfWork.ToDoRepository.GetAllAsync();
        return result.Select(x =>
            new ToDoDto.ToDoDtoResponse
            {
                ID = x.ID,
                Category = new CategoryDto.CategoryDtoResponse
                {
                    Description = x.Category?.Description,
                    ID = x.Category != null ? x.Category.ID : -1,
                    Name = x.Category?.Name,
                },
                Description = x.Description,
                DateAdded = x.DateAdded,
                DueDate = x.DueDate,
                IsCompleted = x.IsCompleted,
                Title = x.Title,
            }
        ).ToList();
    }
    public async Task<ToDoDto.ToDoDtoResponse> GetById(int id)
    {
        ToDo? toDo = await _unitOfWork.ToDoRepository.GetAsync(x => x.ID == id);
        if(toDo == null)
        {
            throw new ApplicationException($"Couldn't find ToDo with ID {id}");
        }
        return new ToDoDto.ToDoDtoResponse
        {
            ID = toDo.ID,
            Category = new CategoryDto.CategoryDtoResponse
            {
                Description = toDo.Category?.Description,
                ID = toDo.Category != null ? toDo.Category.ID : -1,
                Name = toDo.Category?.Name,            },
            Description = toDo.Description,
            DateAdded = toDo.DateAdded,
            DueDate = toDo.DueDate,
            IsCompleted = toDo.IsCompleted,
            Title = toDo.Title,
        };
    }
    public async Task UpdateToDo(int id, ToDoDto.ToDoDtoRequest addToDo)
    {
        ToDo? todo = await _unitOfWork.ToDoRepository.GetAsync(x => x.ID == id);
        if(todo == null)
        {
            throw new ApplicationException($"Couldn't find ToDo with ID {id}");
        }
        todo.DueDate = (DateTime)(addToDo.DueDate != null ? addToDo.DueDate : todo.DueDate);
        todo.Description = addToDo.Description;
        todo.Title = addToDo.Title;
        todo.CategoryID = addToDo.CategoryID;
        todo.IsCompleted = addToDo.IsCompleted;
        todo.DateAdded = (DateTime)addToDo.DateAdded!;
        _unitOfWork.ToDoRepository.Update(todo);
        await _unitOfWork.SaveAsync();
    }
}