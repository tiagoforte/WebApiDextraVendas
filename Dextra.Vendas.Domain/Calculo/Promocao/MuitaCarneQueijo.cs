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
  public class MuitaCarneQueijo : CalculoBase
  {



    public MuitaCarneQueijo(PedidoCommand pedido, List<IngredienteEntity> ingredientes) : base(pedido, ingredientes)
    {

    }

    public override decimal Calcular(decimal valorPedido)
    {

      var ingredienteCarne = Ingredientes.FirstOrDefault(x => x.Nome.ToLower().Contains("carne"));
      var ingredienteQueijo = Ingredientes.FirstOrDefault(x => x.Nome.ToLower().Contains("queijo"));      

      var valorDescontoCarne = (Pedido.ItensPedido.FirstOrDefault(x => x.IdIngrediente == ingredienteCarne?.Id)?.Quantidade / 3) * ingredienteCarne?.Valor;
      var valorDescontoQueijo = (Pedido.ItensPedido.FirstOrDefault(x => x.IdIngrediente == ingredienteQueijo?.Id)?.Quantidade / 3) * ingredienteQueijo?.Valor;

      return valorDescontoCarne ?? 0 + valorDescontoQueijo ?? 0;
    }

  }
}
