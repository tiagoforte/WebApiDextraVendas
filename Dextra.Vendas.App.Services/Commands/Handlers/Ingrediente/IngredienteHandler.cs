using Dextra.Vendas.Domain.Commands.Ingrediente;
using Dextra.Vendas.Domain.Converters;
using Dextra.Vendas.Domain.Entities;
using Dextra.Vendas.Domain.Repositories.Ingrediente;
using Dextra.Vendas.Domain.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.App.Services.Commands.Handlers.Ingrediente
{
  public class IngredienteHandler
  {
    private readonly IIngredienteRepository _repository;

    public IngredienteHandler(IIngredienteRepository repository)
    {
      this._repository = repository;
    }


    public IDtoResult HandleAdd(AddIngredienteCommand command)
    {
      var ingrediente = new IngredienteEntity(command.Nome, command.Valor);
      _repository.Add(ingrediente);

      return ingrediente.ToDto();
    }

    public IDtoResult HandleUpdate(UpdateIngredienteCommand command)
    {

      var ingrediente = _repository.GetById(command.Id);
      ingrediente.Update(command);
      _repository.Update(ingrediente);

      return ingrediente.ToDto();
    }

    public void HandleRemove(int Id)
    {
      var ingrediente = _repository.GetById(Id);      
      _repository.Remove(ingrediente);
      
    }


  }
}
