using Dextra.Vendas.App.Services.Commands.Handlers;
using Dextra.Vendas.App.Services.Commands.Handlers.Ingrediente;
using Dextra.Vendas.App.Services.Commands.Handlers.Lanche;
using Dextra.Vendas.App.Services.Queries.Ingrediente;
using Dextra.Vendas.App.Services.Queries.Lanche;
using Dextra.Vendas.Domain.Contracts;
using Dextra.Vendas.Domain.Repositories.Comum;
using Dextra.Vendas.Domain.Repositories.Ingrediente;
using Dextra.Vendas.Domain.Repositories.Lanche;
using Dextra.Vendas.Domain.Shared;
using Dextra.Vendas.InfraV2.Context;
using Dextra.Vendas.InfraV2.Repositories.Comum;
using Dextra.Vendas.InfraV2.Repositories.Ingrediente;
using Dextra.Vendas.InfraV2.Repositories.Lanche;
using Dextra.Vendas.InfraV2.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dextra.Vendas.Api.IOC
{
  public static class DependencyInjection
  {
    public static void AddDependency(IServiceCollection Services)
    {

      // Transacionais
      Services.AddTransient<IUnitOfWork, UnitOfWork>();
      Services.AddDbContext<DataContext>(options => options.UseSqlServer(Runtime.ConnectionString));

      //Querys
      Services.AddTransient<IngredienteQuery, IngredienteQuery>();
      Services.AddTransient<LancheQuery, LancheQuery>();

      // Handlers
      Services.AddTransient<IngredienteHandler, IngredienteHandler>();
      Services.AddTransient<LancheHandler, LancheHandler>();
      Services.AddTransient<CalculoHandler, CalculoHandler>();

      // Repositorios
      Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
      Services.AddTransient<IIngredienteRepository, IngredienteRepository>();
      Services.AddTransient<ILancheRepository, LancheRepository>();      
    }

  }
}
