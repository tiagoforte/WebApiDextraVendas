using Dextra.Vendas.Domain.Dtos;
using Dextra.Vendas.Domain.Dtos.Generic;
using Dextra.Vendas.Domain.Entities;
using Dextra.Vendas.Domain.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Converters
{
  public static class LancheConvert
  {
    public static LancheDto ToDto(this LancheEntity lancheEntity)
    {
      var ret = new LancheDto(lancheEntity.Id, lancheEntity.Nome, lancheEntity.Valor) { Ingredientes = lancheEntity.Ingredientes.Select(y => new IngredienteDto(y.Ingrediente.Id, y.Ingrediente.Nome, y.Ingrediente.Valor)).ToList() };
      return ret;
    }

    public static GenericListDto<LancheDto> ToDto(this List<LancheEntity> lanchesEntity)
    {
      return new GenericListDto<LancheDto>(lanchesEntity.Select(x => new LancheDto(x.Id, x.Nome, x.Valor)).ToList());
    }

  }
}
