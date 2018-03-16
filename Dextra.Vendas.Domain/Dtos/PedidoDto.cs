using Dextra.Vendas.Domain.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Dtos
{
  public class PedidoDto : IDtoResult
  {
    public string Lanche { get; set; }
    public decimal Valor { get; set; }
    public decimal Desconto { get; set; }
    public decimal ValorFinal { get; set; }
  }
}
