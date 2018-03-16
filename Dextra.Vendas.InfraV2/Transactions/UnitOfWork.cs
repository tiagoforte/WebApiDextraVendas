using Dextra.Vendas.Domain.Contracts;
using Dextra.Vendas.InfraV2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.InfraV2.Transactions
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
      this._context = context;
    }

    public void Commit()
    {
      _context.SaveChanges();
    }

    public void Rollback()
    {
      throw new NotImplementedException();
    }
  }
  
}
