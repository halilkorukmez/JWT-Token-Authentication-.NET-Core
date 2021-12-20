using DataAccess.Entityframework.Dal.UserDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IUserDal User { get; }
        Task<int> SaveAsync();
    }
}
