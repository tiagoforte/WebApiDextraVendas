using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Commands.Ingrediente
{
  public class UpdateIngredienteCommand
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
  }
}
