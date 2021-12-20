using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result.Abstract
{
    public interface IDataResult<out T> : IResult
    {                              //new DataResult<IList<Product>>(ResultStatus.Success,productList)
        public T Data { get; }    //new DataResult<Product>(ResultStatus.Success,product)

    }
}
