using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dextra.Vendas.Api.Controllers.Comum;
using Dextra.Vendas.App.Services.Commands.Handlers.Ingrediente;
using Dextra.Vendas.App.Services.Queries.Ingrediente;
using Dextra.Vendas.Domain.Commands.Ingrediente;
using Dextra.Vendas.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dextra.Vendas.Api.Controllers
{

  [Route("api/v1/Ingredientes/")]
  public class IngredienteController : BaseController
  {
    private readonly IngredienteHandler _handler;
    private readonly IngredienteQuery _query;

    public IngredienteController(IUnitOfWork unitOfWork, IngredienteHandler handler, IngredienteQuery query) : base(unitOfWork)
    {
      this._handler = handler;
      this._query = query;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        var result = this._query.GetAll();
        return await Response(result);
      }
      catch (Exception ex)
      {
        return await base.Errors(ex);
      }
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IActionResult> Get(int Id)
    {
      try
      {
        var result = this._query.GetById(Id);
        return await Response(result);
      }
      catch (Exception ex)
      {
        return await base.Errors(ex);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddIngredienteCommand command)
    {
      try
      {
        var Result = _handler.HandleAdd(command);
        return await Response(Result);
      }
      catch (Exception ex)
      {
        return await base.Errors(ex);
      }
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateIngredienteCommand command)
    {
      try
      {
        var Result = _handler.HandleUpdate(command);
        return await Response(Result);
      }
      catch (Exception ex)
      {
        return await base.Errors(ex);
      }
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> Delete(int Id)
    {
      try
      {
        _handler.HandleRemove(Id);
        return await Response(Id);
      }
      catch (Exception ex)
      {
        return await base.Errors(ex);
      }
    }


  }
}
