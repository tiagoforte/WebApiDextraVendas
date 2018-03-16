using Dextra.Vendas.Domain.Entities;
using Dextra.Vendas.Domain.Repositories.Ingrediente;
using Dextra.Vendas.InfraV2.Context;
using Dextra.Vendas.InfraV2.Repositories.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.InfraV2.Repositories.Ingrediente
{
  public class IngredienteRepository: RepositoryBase<IngredienteEntity>, IIngredienteRepository
  {
    public IngredienteRepository(DataContext context)
    {
      this._context = context;
    }

  }
}
