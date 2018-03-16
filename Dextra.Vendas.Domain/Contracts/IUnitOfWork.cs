using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Contracts
{
  public interface IUnitOfWork
  {
    void Commit();
    void Rollback();
  }
}
