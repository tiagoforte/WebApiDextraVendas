using Dextra.Vendas.Domain.Calculo.Core;
using Dextra.Vendas.Domain.Commands.Pedido;
using Dextra.Vendas.Domain.Entities;
using Dextra.Vendas.Domain.Repositories.Ingrediente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Calculo.Promocao
{
  public class Light : CalculoBase
  {



    public Light(PedidoCommand pedido, List<IngredienteEntity> ingredientes) : base(pedido, ingredientes)
    {

    }

    public override decimal Calcular(decimal valorPedido)
    {
      var ingredienteAlface = Ingredientes.FirstOrDefault(x => x.Nome.ToLower().Contains("alface"));
      var ingredienteBacon = Ingredientes.FirstOrDefault(x => x.Nome.ToLower().Contains("bacon"));

      if (this.Pedido.ItensPedido.Any(x => x.IdIngrediente == ingredienteAlface?.Id) && !this.Pedido.ItensPedido.Any(x => x.IdIngrediente == ingredienteBacon?.Id))
        return ((valorPedido * 10) / 100);

      return 0;
    }

  }
}
