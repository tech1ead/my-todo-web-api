using System.ComponentModel.DataAnnotations.Schema;

namespace MyToDoWebApi.Database.Models;
public class ToDo
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public int CategoryID { get; set; }
    public virtual Category? Category { get; set; }
    public DateTime DateAdded { get; set; }
}
