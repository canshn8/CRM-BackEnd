using AutoMapper;
using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var exist = _authService.UserExists(userForRegisterDto.Email);
            if (!exist.Success)
            {
                return BadRequest("bu kullanıcı zaten kayıtlı");
            }
            userForRegisterDto.Status = true;
            var register=_authService.Register(userForRegisterDto);
            var check = _authService.CreateAccessToken(register.Data);
            if (!check.Success)
            {
                return BadRequest("token oluşmadı");
            }
            return Ok(register);
        }


        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDto userForLogin)
        {
            
        }
    }
}
