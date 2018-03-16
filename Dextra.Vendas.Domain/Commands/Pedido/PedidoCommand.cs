using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Commands.Pedido
{
  public class PedidoCommand
  {
    public int IdLanche { get; set; }
    public List<ItensPedidoCommand> ItensPedido { get; set; }
  }
}
