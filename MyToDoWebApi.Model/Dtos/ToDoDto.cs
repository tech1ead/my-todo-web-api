namespace MyToDoWebApi.Model.Dtos;
public class ToDoDto
{
    public class ToDoDtoResponse
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public CategoryDto.CategoryDtoResponse? Category { get; set; }
        public DateTime? DateAdded { get; set; }
    }
    public class ToDoDtoRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int CategoryID { get; set; }
        public DateTime? DateAdded { get; set; } = DateTime.Now;
    }
}