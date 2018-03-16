using Dextra.Vendas.Domain.Repositories.Comum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.InfraV2.Repositories.Comum
{
  public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
  {
    protected DbContext _context;


    public List<TEntity> GetAll(params object[] includes)
    {
      var query = _context.Set<TEntity>().AsQueryable();
      if (query == null)
      {
        return null;
      }

      foreach (string include in includes)
      {
        query = query.Include(include);
      }
      return query.ToList();
    }

    public TEntity GetById<T>(T id, params object[] includes)
    {
      var query = _context.Set<TEntity>().Find(id);
      if (query == null)
      {
        return null;
      }
      foreach (string include in includes)
      {
        var memberEntry = _context.Entry(query).Member(include);

        if (memberEntry is CollectionEntry)
          _context.Entry(query).Collection(include).Load();
        if (memberEntry is ReferenceEntry)
          _context.Entry(query).Reference(include).Load();
      }
      return query;
    }


    public List<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params object[] includes)
    {
      var query = _context.Set<TEntity>().AsQueryable();
      if (query == null)
      {
        return null;
      }
      foreach (string include in includes)
      {
        query = query.Include(include);
      }
      return query.Where(predicate).ToList();
    }

    public void Add(TEntity obj)
    {
      _context.Set<TEntity>().Add(obj);
    }

    public void Update(TEntity obj)
    {
      _context.Set<TEntity>().Update(obj);
    }

    public void Remove(TEntity obj)
    {
      _context.Entry<TEntity>(obj).State = EntityState.Deleted;
    }

    public void Dispose()
    {
      if (_context != null)
      {
        _context.Dispose();
      }
      GC.SuppressFinalize(this);
    }
  }
}
