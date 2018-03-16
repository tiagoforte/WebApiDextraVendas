using Dextra.Vendas.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.InfraV2.Context
{
  public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
  {
   
    public DataContext CreateDbContext(string[] args)
    {
      var builder = new DbContextOptionsBuilder<DataContext>();     
      builder.UseSqlServer(Runtime.ConnectionString);
      return new DataContext(builder.Options);
    }
  }

 
}
