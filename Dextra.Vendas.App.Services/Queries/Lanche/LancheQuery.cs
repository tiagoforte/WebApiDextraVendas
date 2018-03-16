using Dextra.Vendas.Domain.Converters;
using Dextra.Vendas.Domain.Repositories.Lanche;
using Dextra.Vendas.Domain.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.App.Services.Queries.Lanche
{
  public class LancheQuery
  {
    private readonly ILancheRepository _repository;

    public LancheQuery(ILancheRepository repository)
    {
      this._repository = repository;
    }

    public IDtoResult GetAll()
    {
      var Lanches = _repository.GetAll();
      return Lanches.ToDto();
    }

    public IDtoResult GetById(int Id)
    {
      var lanche = _repository.GetById(Id,"Ingredientes");
      return lanche.ToDto();
    }

  }
}
