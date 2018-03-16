using Dextra.Vendas.Domain.Commands.Lanche;
using Dextra.Vendas.Domain.Converters;
using Dextra.Vendas.Domain.Entities;
using Dextra.Vendas.Domain.Repositories.Lanche;
using Dextra.Vendas.Domain.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.App.Services.Commands.Handlers.Lanche
{
  public class LancheHandler
  {

    private readonly ILancheRepository _repository;

    public LancheHandler(ILancheRepository repository)
    {
      this._repository = repository;
    }


    public IDtoResult HandleAdd(AddLancheCommand command)
    {
      var lanche = new LancheEntity(command.Nome, command.Valor);
      _repository.Add(lanche);

      return lanche.ToDto();
    }

    public IDtoResult HandleUpdate(UpdateLancheCommand command)
    {

      var lanche = _repository.GetById(command.Id);
      lanche.Update(command);
      _repository.Update(lanche);

      return lanche.ToDto();
    }

    public void HandleRemove(int Id)
    {
      var lanche = _repository.GetById(Id);
      _repository.Remove(lanche);

    }


  }
}
