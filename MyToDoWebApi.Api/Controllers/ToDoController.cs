using Microsoft.AspNetCore.Mvc;
using MyToDoWebApi.Model.Dtos;
using MyToDoWebApi.Service.ToDoService;
namespace MyToDoWebAPI.Controllers;

[Route("api/todo")]
[ApiController]
public class ToDoController : Controller
{
    private readonly IToDoService _toDoService;
    public ToDoController(IToDoService toDoService)
    {
        _toDoService = toDoService;
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAllToDos()
    {
        return Ok(await _toDoService.GetAll());
    }
    [HttpGet("single")]
    public async Task<IActionResult> GetTodoById([FromQuery] int todoId)
    {
        return Ok(await _toDoService.GetById(todoId));
    }
    [HttpDelete("remove")]
    public async Task<IActionResult> RemoveToDo([FromQuery] int todoId)
    {
        await _toDoService.DeleteById(todoId);
        return NoContent();
    }
    [HttpPost("add")]
    public async Task<IActionResult> AddToDo([FromBody] ToDoDto.ToDoDtoRequest todoDto)
    {
        await _toDoService.AddToDo(todoDto);
        return Ok();
    }
    [HttpPut("update")]
    public async Task<IActionResult> UpdateToDo([FromQuery] int todoId, [FromBody] ToDoDto.ToDoDtoRequest toDoDto)
    {
        await _toDoService.UpdateToDo(todoId, toDoDto);
        return Ok();
    }
}