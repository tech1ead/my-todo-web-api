namespace MyToDoWebApi.Model.Dtos;
public class CategoryDto
{
    public class CategoryDtoResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
    public class CategoryDtoRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}