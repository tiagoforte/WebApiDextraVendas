using Dextra.Vendas.Domain.Calculo.Core;
using Dextra.Vendas.Domain.Commands.Pedido;
using Dextra.Vendas.Domain.Repositories.Ingrediente;
using Dextra.Vendas.Domain.Repositories.Lanche;
using Dextra.Vendas.Domain.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.App.Services.Commands.Handlers
{
  public class CalculoHandler
  {
    private readonly IIngredienteRepository _ingredienteRepository;
    private readonly ILancheRepository _lancheRepository;

    public CalculoHandler(IIngredienteRepository ingredienteRepository, ILancheRepository lancheRepository)
    {
      this._ingredienteRepository = ingredienteRepository;
      this._lancheRepository = lancheRepository;
    }


    public IDtoResult Calcular(PedidoCommand pedidoCommand)
    {      
      return CalculoCore.Calcular(pedidoCommand, this._ingredienteRepository, this._lancheRepository);
    }


  }
}
