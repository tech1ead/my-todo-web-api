using System.ComponentModel.DataAnnotations.Schema;

namespace MyToDoWebApi.Database.Models;
public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<ToDo>? ToDos { get; set; }
}