using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.ProductDataServices;
using Services.UserServices;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _userService.GetListAsync();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _userService.GetAsync(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetByUserNameAsync(string username)
        {
            var result = await _userService.GetByUserNameAsync(username);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddAsync([FromBody]User user)
        {
            var result = await _userService.AddAsync(user);
            if (result != null)
                return Ok(result);
            return BadRequest();

        }


        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _userService.DeleteAsync(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        
    }

}
