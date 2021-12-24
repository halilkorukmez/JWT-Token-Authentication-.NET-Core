using AutoMapper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.ComplexTypes;
using Core.Utilities.Result.Concrete;
using DataAccess.DataContext;
using DataAccess.UnitOfWork;
using Entities;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AuthDataContext _dataContext;
        public UserService(IUnitOfWork unitOfWork ,AuthDataContext dataContext)
        {
            _unitOfWork = unitOfWork;
           
            _dataContext = dataContext;
        }

        public async Task<IResult> AddAsync(User user)
        {
            if (_dataContext.Users.Any(x => x.UserName == user.UserName))
                return new Result(ResultStatus.Error, $"{user.UserName} kullanıcı adı daha önceden alınmış");
           
            else
                await _unitOfWork.User.AddAsync(user)
                    .ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{user.Name} adlı kullanıcı başarıyla eklenmiştir.");
            
           
        }

        public async Task<IResult> DeleteAsync(Guid userId)
        {
            var user = await _unitOfWork.User.GetAsync(p => p.Id == userId);
            if (user != null)
            {
                user.IsActive = false;
                await _unitOfWork.User.DeleteAsync(user).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{user.Name} silindi.");
            }
            return new Result(ResultStatus.Error, "Kayıtlı Bir kullanıcı Bulunamadı");
        }

        public async Task<IDataResult<UserDto>> GetAsync(Guid id)
        {
            var user = await _unitOfWork.User.GetAsync(p => p.Id == id);
            if (user != null)
            {
                return new DataResult<UserDto>(ResultStatus.Success, new UserDto
                {
                    User = user,
                    ResultStatus = ResultStatus.Success
                }); ;
            }
            return new DataResult<UserDto>(ResultStatus.Error, "Kayıtlı Bir Ürün Bulunamadı", null);
        }

        public async Task<IDataResult<UserDto>> GetByUserNameAsync(string username)
        {
            var user = await _unitOfWork.User.GetAsync(p => p.UserName == username);
            if (user != null)
            {
                return new DataResult<UserDto>(ResultStatus.Success, new UserDto
                {
                    User = user,
                    ResultStatus = ResultStatus.Success
                }); ;
            }
            return new DataResult<UserDto>(ResultStatus.Error, "Kayıtlı Bir Ürün Bulunamadı", null);
        }

        public async Task<IDataResult<UserListDto>> GetListAsync()
        {
            var users = await _unitOfWork.User.GetListAsync(p => p.IsActive == true);
            if (users.Count >= 0)
            {
                return new DataResult<UserListDto>(ResultStatus.Success, new UserListDto
                {
                    User = users,
                    ResultStatus = ResultStatus.Success
                });

            }
            return new DataResult<UserListDto>(ResultStatus.Error, "Kayıtlı Bir Ürün Bulunamadı", null);
        }

        public async Task<User> LoginAsync(string userName, string password)
        {
            try
            {
               return await _dataContext.Users.FirstOrDefaultAsync(f => f.UserName == userName && f.Password == password);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Task<IResult> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
