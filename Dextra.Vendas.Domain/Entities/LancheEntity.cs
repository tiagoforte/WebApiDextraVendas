using Dextra.Vendas.Domain.Commands.Lanche;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Entities
{
  public class LancheEntity
  {
    protected LancheEntity() { }

    public LancheEntity(string nome, decimal valor)
    {
      this.Nome = nome;
      this.Valor = valor;
      this.Ingredientes = new List<LancheIngredientesEntity>();
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Valor { get; private set; }
    public ICollection<LancheIngredientesEntity> Ingredientes { get; private set; }

    public void Update(UpdateLancheCommand command)
    {
      this.Nome = command.Nome;
      this.Valor = command.Valor;
    }

  }
}
