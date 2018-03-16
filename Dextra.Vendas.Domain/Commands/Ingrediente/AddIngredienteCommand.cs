using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Commands.Ingrediente
{
  public class AddIngredienteCommand
  {
    public string Nome { get; set; }
    public decimal Valor { get; set; }

  }
}
