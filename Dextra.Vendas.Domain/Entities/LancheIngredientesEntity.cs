using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Entities
{
  public class LancheIngredientesEntity
  {
    protected LancheIngredientesEntity() { }
  
    public LancheIngredientesEntity(int idLanche, int idIngrediente)
    {
      this.IdLanche = idLanche;
      this.IdIngrediente = idIngrediente;
    }
    public int IdLanche { get; private set; }
    public virtual LancheEntity Lanche { get; set; }

    public int IdIngrediente { get; private set; }
    public virtual IngredienteEntity Ingrediente { get; set; }


  }
}
