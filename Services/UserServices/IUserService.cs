using Core.Utilities.Result.Abstract;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserServices
{
    public interface IUserService
    {
        Task<IDataResult<UserDto>> GetAsync(Guid id);
        Task<IDataResult<UserListDto>> GetListAsync();
        Task<IResult> AddAsync(User user);
        Task<IResult> UpdateAsync(User user);
        Task<IResult> DeleteAsync(Guid userId);
        Task<User> LoginAsync(string name, string password);
    }
}
