using Microsoft.EntityFrameworkCore;
using MyToDoWebApi.Database.Models;
namespace MyToDoWebApi.Database.Context;
public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }
    public virtual DbSet<ToDo> ToDos { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
}