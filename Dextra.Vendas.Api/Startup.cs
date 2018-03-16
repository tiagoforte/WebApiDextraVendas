using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dextra.Vendas.Domain.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dextra.Vendas.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");
      
      Configuration = builder.Build();

      Runtime.ConnectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddCors();

      IOC.DependencyInjection.AddDependency(services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod()
       );
      app.UseMvc();
    }
  }
}
