using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyToDoWebApi.Database.Models;
using System.Reflection;
namespace MyToDoWebApi.Database.Context;
public class ToDoContext : DbContext
{
    public ToDoContext() { }
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }
    public virtual DbSet<ToDo> ToDos { get; set; }
    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        string executable = Assembly.GetExecutingAssembly().Location;
        string path = Path.GetDirectoryName(executable)!;
        AppDomain.CurrentDomain.SetData("DataDirectory", path);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<ToDo>()
            .HasOne(c => c.Category)
            .WithMany(c => c.ToDos)
            .HasForeignKey(c => c.CategoryID);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:ToDoContext"]);
        }
        base.OnConfiguring(optionsBuilder);
    }
}