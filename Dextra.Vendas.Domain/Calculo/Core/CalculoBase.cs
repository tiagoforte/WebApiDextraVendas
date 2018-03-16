using Dextra.Vendas.Domain.Commands.Pedido;
using Dextra.Vendas.Domain.Entities;
using Dextra.Vendas.Domain.Repositories.Ingrediente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Calculo.Core
{
  public abstract class CalculoBase
  {
    public PedidoCommand Pedido { get; private set; }
    public List<IngredienteEntity> Ingredientes { get; private set; }

    public CalculoBase(PedidoCommand pedido, List<IngredienteEntity> ingredientes)
    {
      this.Pedido = pedido;
      this.Ingredientes = ingredientes;
    }
    public abstract decimal Calcular(decimal valorPedido);
  }
}
