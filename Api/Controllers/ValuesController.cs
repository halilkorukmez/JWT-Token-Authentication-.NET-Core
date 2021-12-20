using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.ProductDataServices;
using Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        
        public LoginController(IUserService userService,
            ITokenService tokenService)
        {
            
            _userService = userService;
            _tokenService = tokenService;
        }



        [HttpPost("getToken")]
        public async Task<string> GetTokenAsync(string userName, string password)
        {
            var user = await _userService.LoginAsync(userName, password);
            if (user == null)
            {
                return ("UYARI : Kullanıcı Bilgilerinizi Eksiksiz Girdiğinizden Emin Olun. Eğer Eksiksiz Doldurduysanız :" +
                    Environment.NewLine
                    + "DİKKAT : Servis Kullanım Süreniz Dolmuştur ");



            }
            else
            {
                var token = _tokenService.GetToken(user);
                var response = new
                {
                    Status = true,
                    Token = token,
                    Type = "Bearer", 
                    UserId = user.Id
                };
                return JsonConvert.SerializeObject(response);
            }

        }
    }
}
