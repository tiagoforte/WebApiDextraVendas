using Dextra.Vendas.Domain.Commands.Ingrediente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Entities
{
  public class IngredienteEntity
  {
    protected IngredienteEntity() { }

    public IngredienteEntity(string nome, decimal valor)
    {
      this.Nome = nome;
      this.Valor = valor;
      this.Lanches = new List<LancheIngredientesEntity>();
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Valor { get; private set; }
    public ICollection<LancheIngredientesEntity> Lanches { get; private set; }


    public void Update(UpdateIngredienteCommand command)
    {
      this.Nome = command.Nome;
      this.Valor = command.Valor;
    }
  }
}
