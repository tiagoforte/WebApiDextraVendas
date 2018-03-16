using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dextra.Vendas.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dextra.Vendas.Api.Controllers.Comum
{
  [Produces("application/json")]
  [Route("api/Base")]
  public class BaseController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    public BaseController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<IActionResult> Response(object Result)
    {
      try
      {
        _unitOfWork.Commit();
        return Ok(new { success = true, data = Result });
      }
      catch (Exception ex)
      {
        return await Errors(ex);
      }
    }

    public async Task<IActionResult> Errors(Exception ex)
    {
      return BadRequest(new { success = false, error = ex?.Message });
    }

  }
}
