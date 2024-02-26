using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_course.Data;
using Backend_course.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace Backend_course.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        public IAuthRepository _authRepo { get; }
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(
                new User { Username = request.Username }, request.Password
            );
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request)
        {
            var response = await _authRepo.Login(request.Username, request.Password);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}