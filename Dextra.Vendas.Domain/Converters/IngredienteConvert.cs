using Dextra.Vendas.Domain.Dtos;
using Dextra.Vendas.Domain.Dtos.Generic;
using Dextra.Vendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Converters
{
  public static class IngredienteConvert
  {
    public static IngredienteDto ToDto(this IngredienteEntity ingredienteEntity)
    {
      return new IngredienteDto(ingredienteEntity.Id, ingredienteEntity.Nome, ingredienteEntity.Valor);
    }

    public static GenericListDto<IngredienteDto> ToDto(this List<IngredienteEntity> ingredientesEntity)
    {
      return new GenericListDto<IngredienteDto>(ingredientesEntity.Select(x => new IngredienteDto(x.Id, x.Nome, x.Valor)).ToList());
    }

  }
}
