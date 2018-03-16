using Dextra.Vendas.Domain.Converters;
using Dextra.Vendas.Domain.Dtos;
using Dextra.Vendas.Domain.Repositories.Ingrediente;
using Dextra.Vendas.Domain.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.App.Services.Queries.Ingrediente
{
  public class IngredienteQuery
  {
    private readonly IIngredienteRepository _repository;

    public IngredienteQuery(IIngredienteRepository repository)
    {
      this._repository = repository;
    }

    public IDtoResult GetAll()
    {
      var ingredientes = _repository.GetAll();
      return ingredientes.ToDto();
    }

    public IDtoResult GetById(int Id)
    {
      var ingrediente = _repository.GetById(Id);
      return ingrediente.ToDto();
    }

  }

}
