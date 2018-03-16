using Dextra.Vendas.Domain.Entities;
using Dextra.Vendas.InfraV2.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.InfraV2.Context
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> option) : base(option)
    {
      
    }

    public DbSet<IngredienteEntity> Ingrediente { get; set; }
    public DbSet<LancheEntity> Lanche { get; set; }
    public DbSet<LancheIngredientesEntity> LancheIngredientes { get; set; }    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {     
      modelBuilder.ApplyConfiguration(new IngredienteMap());
      modelBuilder.ApplyConfiguration(new LancheMap());
      modelBuilder.ApplyConfiguration(new LancheIngredientesMap());      
    }
  }
}
