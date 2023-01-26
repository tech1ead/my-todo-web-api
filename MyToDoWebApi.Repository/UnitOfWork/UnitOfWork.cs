using MyToDoWebApi.Database.Context;
using MyToDoWebApi.Repository.CategoryRepository;
using MyToDoWebApi.Repository.ToDoRepository;
namespace MyToDoWebApi.Repository.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly ToDoContext _dbContext;
    public IToDoRepository ToDoRepository { get; set; }
    public ICategoryRepository CategoryRepository { get; set; }

    public UnitOfWork(ToDoContext dbContext)
    {
        _dbContext = dbContext;
        ToDoRepository = new ToDoRepository.ToDoRepository(_dbContext);
        CategoryRepository = new CategoryRepository.CategoryRepository(_dbContext);
    }
    public async Task RollbackAsync()
        => await _dbContext.DisposeAsync();
    
    public async Task SaveAsync()
        => await _dbContext.SaveChangesAsync();
    
}