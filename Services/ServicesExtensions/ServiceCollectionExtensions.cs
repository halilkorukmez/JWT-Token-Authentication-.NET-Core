using DataAccess.DataContext;
using DataAccess.Entityframework.Dal.UserDal;
using DataAccess.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Services.ProductDataServices;
using Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<AuthDataContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IUserDal , EfUserDal>();
            serviceCollection.AddScoped<ITokenService , TokenService>();



           
            return serviceCollection;
           
        }
    }
}
