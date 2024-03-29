﻿using Microsoft.EntityFrameworkCore;
using MyToDoWebApi.Database.Context;
using System.Linq.Expressions;
namespace MyToDoWebApi.Repository.GenericRepository;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ToDoContext _dbContext;
    private readonly DbSet<T> _entitySet;

    public GenericRepository(ToDoContext dbContext)
    {
        _dbContext = dbContext;
        _entitySet = _dbContext.Set<T>();
    }
    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => await _dbContext.AddAsync(entity, cancellationToken);
    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _entitySet.ToListAsync(cancellationToken);
    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        => await _entitySet.Where(expression).ToListAsync(cancellationToken);
    public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
         => await _entitySet.FirstOrDefaultAsync(expression, cancellationToken);
    public void Remove(T entity)
        => _dbContext.Remove(entity);
    public void Update(T entity)
        => _dbContext.Update(entity);
}