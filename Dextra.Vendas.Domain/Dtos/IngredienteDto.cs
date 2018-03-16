using Dextra.Vendas.Domain.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Dtos
{
  public class IngredienteDto : IDtoResult
  {
    public IngredienteDto(int id, string nome, decimal valor)
    {
      this.Id = id;
      this.Nome = nome;
      this.Valor = valor;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }

  }
}
