using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Commands.Lanche
{
  public class UpdateLancheCommand
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
  }
}
