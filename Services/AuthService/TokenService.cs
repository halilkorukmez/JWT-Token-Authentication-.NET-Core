using AutoMapper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.ComplexTypes;
using Core.Utilities.Result.Concrete;
using DataAccess.Entityframework.Dal.UserDal;
using DataAccess.UnitOfWork;
using Entities;
using Microsoft.Extensions.Options;
using Services.ProductDataService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services.ProductDataServices
{
    public class TokenService : ITokenService
    {
        private readonly JwtSetting _jwtSetting;
        public TokenService(IOptions<JwtSetting> option)
        {
            _jwtSetting = option.Value;
        }
        public string GetToken(User user)
        {

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id.ToString(), ClaimValueTypes.Integer32),
                new Claim("userCode", user.UserCode),
                new Claim("name", user.UserName),
                


            };


            var token = new JwtSecurityToken(
                    issuer: _jwtSetting.Issuer,
                    audience: _jwtSetting.Audience,
                    signingCredentials: _jwtSetting.Credentials,
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddSeconds(_jwtSetting.ExpireSeconds)
                );
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }

}
