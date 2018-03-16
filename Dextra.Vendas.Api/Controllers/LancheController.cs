using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dextra.Vendas.Api.Controllers.Comum;
using Dextra.Vendas.App.Services.Commands.Handlers;
using Dextra.Vendas.App.Services.Commands.Handlers.Lanche;
using Dextra.Vendas.App.Services.Queries.Lanche;
using Dextra.Vendas.Domain.Commands.Lanche;
using Dextra.Vendas.Domain.Commands.Pedido;
using Dextra.Vendas.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dextra.Vendas.Api.Controllers
{

  [Route("api/v1/Lanches/")]
  public class LancheController : BaseController
  {
    private readonly LancheHandler _handler;
    private readonly LancheQuery _query;
    private readonly CalculoHandler _calculoHandler;

    public LancheController(IUnitOfWork unitOfWork, LancheHandler handler, CalculoHandler calculoHandler, LancheQuery query) : base(unitOfWork)
    {
      this._handler = handler;
      this._query = query;
      this._calculoHandler = calculoHandler;
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
    public async Task<IActionResult> Post([FromBody] AddLancheCommand command)
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
    public async Task<IActionResult> Put([FromBody] UpdateLancheCommand command)
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

    [HttpPost]
    [Route("Calcular")]
    public async Task<IActionResult> CalcularPedido([FromBody] PedidoCommand pedidoCommand)
    {
      try
      {
        var Result = _calculoHandler.Calcular(pedidoCommand);
        return await Response(Result);
      }
      catch (Exception ex)
      {
        return await base.Errors(ex);
      }
    }


  }
}
