using Dextra.Vendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.InfraV2.Map
{
  public class LancheIngredientesMap : IEntityTypeConfiguration<LancheIngredientesEntity>
  {
    public LancheIngredientesMap()
    {
      
    }

    public void Configure(EntityTypeBuilder<LancheIngredientesEntity> builder)
    {
      builder.ToTable("LancheIngredientes");
      builder.HasKey(x => new { x.IdLanche, x.IdIngrediente });
      builder.Property(x => x.IdLanche).IsRequired();
      builder.Property(x => x.IdIngrediente).IsRequired();
      builder.HasOne(x => x.Lanche).WithMany(x => x.Ingredientes).HasForeignKey(x => x.IdLanche);
      builder.HasOne(x => x.Ingrediente).WithMany(x => x.Lanches).HasForeignKey(x => x.IdIngrediente);      
    }
  }
}
