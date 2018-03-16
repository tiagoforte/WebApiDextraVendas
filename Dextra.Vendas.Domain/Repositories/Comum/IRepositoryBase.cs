using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Repositories.Comum
{
  public interface IRepositoryBase<TEntity> where TEntity : class
  {

    TEntity GetById<T>(T id, params object[] includes);
    List<TEntity> GetAll(params object[] includes);
    List<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params object[] includes);

    void Add(TEntity obj);
    void Update(TEntity obj);
    void Remove(TEntity obj);

  }
}
