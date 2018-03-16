using Dextra.Vendas.Domain.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Vendas.Domain.Dtos.Generic
{
  public class GenericListDto<T> : IDtoResult
  {
    public GenericListDto(List<T> Obj)
    {
      this.ObjectList = Obj;
    }

    public List<T> ObjectList { get; private set; }
  }
}
