using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncoraCodingExercise.Data.Contract.API;
using EncoraCodingExercise.Model.API;
using EncoraCodingExercise.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EncoraCodingExercise.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepo = authRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegister request)
        {

            ServiceResponse<int> response = await _authRepo.Register(new User
            {
                Username = request.Username,
            }, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLogin request)
        {

            ServiceResponse<string> response = await _authRepo.Login(request.Username, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
