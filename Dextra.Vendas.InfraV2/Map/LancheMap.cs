using Dextra.Vendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.InfraV2.Map
{
  public class LancheMap : IEntityTypeConfiguration<LancheEntity>
  {
    public LancheMap()
    {

    }

    public void Configure(EntityTypeBuilder<LancheEntity> builder)
    {
      builder.ToTable("Lanche");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
      builder.Property(x => x.Valor).IsRequired();
    }
  }
}
