using System;
using Dextra.Vendas.Domain.Calculo.Core;
using Dextra.Vendas.Domain.Repositories.Ingrediente;
using Dextra.Vendas.Domain.Repositories.Lanche;
using Dextra.Vendas.Domain.Shared;
using Dextra.Vendas.InfraV2.Context;
using Dextra.Vendas.InfraV2.Repositories.Ingrediente;
using Dextra.Vendas.InfraV2.Repositories.Lanche;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dextra.Vendas.Domain.Test.Calculo
{
  [TestClass]
  [TestCategory("Calculo Promocao - Entity")]
  public class CalculosTest
  {
    private IIngredienteRepository _ingredienteRepository;
    private ILancheRepository _lancheRepository;

    [TestMethod]
    public void ValorPedidoFinalNaoPodeZerMenorOuIgualAzero()
    {
      var builder = new DbContextOptionsBuilder<DataContext>();
      builder.UseSqlServer(Runtime.ConnectionString);

      this._ingredienteRepository = new IngredienteRepository(new DataContext(builder.Options));
      this._lancheRepository = new LancheRepository(new DataContext(builder.Options));
      var command = new Commands.Pedido.PedidoCommand()
      {
        IdLanche = 1,
        ItensPedido = new System.Collections.Generic.List<Commands.Pedido.ItensPedidoCommand> {
        new Commands.Pedido.ItensPedidoCommand() { IdIngrediente = 3, Quantidade = 3, },
        new Commands.Pedido.ItensPedidoCommand() { IdIngrediente = 1, Quantidade = 2, },
        new Commands.Pedido.ItensPedidoCommand() { IdIngrediente = 5, Quantidade = 1, }
      }
      };

      var ret = CalculoCore.Calcular(command, _ingredienteRepository, _lancheRepository);
      Assert.IsFalse(ret.ValorFinal <= 0, "");
    }

    [TestMethod]
    public void ValorPedidoFinalMenorOuIgualAZero()
    {
      var builder = new DbContextOptionsBuilder<DataContext>();
      builder.UseSqlServer(Runtime.ConnectionString);

      this._ingredienteRepository = new IngredienteRepository(new DataContext(builder.Options));
      this._lancheRepository = new LancheRepository(new DataContext(builder.Options));
      var command = new Commands.Pedido.PedidoCommand() { IdLanche = 99999, ItensPedido = new System.Collections.Generic.List<Commands.Pedido.ItensPedidoCommand> { new Commands.Pedido.ItensPedidoCommand() { IdIngrediente = 1, Quantidade = 1 } } };

      var ret = CalculoCore.Calcular(command, _ingredienteRepository, _lancheRepository);
      Assert.IsTrue(ret.ValorFinal <= 0, "");
    }

  }
}
