using Dextra.Vendas.Domain.Commands.Pedido;
using Dextra.Vendas.Domain.Dtos;
using Dextra.Vendas.Domain.Repositories.Ingrediente;
using Dextra.Vendas.Domain.Repositories.Lanche;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Calculo.Core
{
  public static class CalculoCore
  {

    public static PedidoDto Calcular(PedidoCommand pedidoCommand, IIngredienteRepository ingredientesRepository, ILancheRepository lancheRepository)
    {
      var pedido = new PedidoDto();

      try
      {
        var AssemblyCurrent = Assembly.GetExecutingAssembly();
        var promocoes = AssemblyCurrent.GetTypes().Where(x => x.IsSubclassOf(typeof(CalculoBase)));
        var listaIngredientes = ingredientesRepository.GetAll();

        pedido.Lanche = lancheRepository.GetById(pedidoCommand.IdLanche).Nome;
        pedido.Valor = pedidoCommand.ItensPedido.Sum(x => (listaIngredientes.FirstOrDefault(y => y.Id == x.IdIngrediente).Valor * x.Quantidade));
        var valorDesconto = 0.0m;

        foreach (var item in promocoes)
        {
          var parametros = new List<object>() { pedidoCommand, listaIngredientes };          
          var instancia = (CalculoBase)Activator.CreateInstance(item, parametros.ToArray());
          valorDesconto += instancia.Calcular(pedido.Valor);
        }

        pedido.Desconto = valorDesconto;
        pedido.ValorFinal = (pedido.Valor - valorDesconto);
        return pedido;
      }
      catch (Exception)
      {
        return new PedidoDto() { ValorFinal = -1 };
      }
    }


  }
}
