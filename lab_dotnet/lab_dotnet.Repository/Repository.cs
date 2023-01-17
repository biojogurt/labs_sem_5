using System.Linq.Expressions;
using lab_dotnet.Entities;
using lab_dotnet.Entities.Models;
using lab_dotnet.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Repository;

public class Repository<T> : IRepository<T> where T : class, IBaseEntity
{
    private readonly Context context;
    private readonly ILogger<Repository<T>> logger;

    public Repository(Context context, ILogger<Repository<T>> logger)
    {
        this.context = context;
        this.logger = logger;
    }

    public IQueryable<T> GetAll()
    {
        return context.Set<T>();
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        return context.Set<T>().Where(predicate);
    }

    public T? GetById(Guid id)
    {
        return context.Set<T>().FirstOrDefault(x => x.Id == id);
    }

    private T Insert(T obj)
    {
        try
        {
            obj.Init();
            var result = context.Set<T>().Add(obj);
            context.SaveChanges();
            return result.Entity;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            throw;
        }
    }

    private T Update(T obj)
    {
        try
        {
            obj.ModificationTime = DateTime.UtcNow;
            var result = context.Set<T>().Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
            return result.Entity;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            throw;
        }
    }

    public T Save(T obj)
    {
        try
        {
            return obj.IsNew() ? Insert(obj) : Update(obj);
        }
        catch (Exception ex)
        {
            throw new RepositoryException(ex.ToString());
        }
    }

    public void Delete(T obj)
    {
        try
        {
            context.Set<T>().Attach(obj);
            context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            throw new RepositoryException(ex.ToString());
        }
    }
}