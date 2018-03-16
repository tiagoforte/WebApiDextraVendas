using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Commands.Pedido
{
  public class ItensPedidoCommand
  {
    public int IdIngrediente { get; set; }
    public int Quantidade { get; set; }

  }
}
