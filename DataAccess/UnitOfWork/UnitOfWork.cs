using DataAccess.DataContext;
using DataAccess.Entityframework.Dal.UserDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuthDataContext _context;
        private EfUserDal _efUserDal;


     

        public UnitOfWork(AuthDataContext context)
        {
            _context = context;
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public IUserDal User => _efUserDal ?? new EfUserDal(_context);

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
}
