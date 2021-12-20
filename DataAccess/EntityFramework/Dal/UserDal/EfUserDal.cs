using Core.ServicesModel;
using DataAccess.DataContext;
using Entities;


namespace DataAccess.Entityframework.Dal.UserDal
{
   public class EfUserDal : ServiceModel<User>, IUserDal
    {
        public EfUserDal(AuthDataContext dbContext) : base(dbContext)
        {

        }

    }
}
