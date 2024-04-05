using ApiEmployee.Domain.Models;
using ApiEmployee.Domain.Ports.In.Usecases;
using ApiEmployee.Dtos.Authentications;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ISignInUseCase signInUseCase, IMapper mapper) : ControllerBase
    {
        private readonly ISignInUseCase signInUseCase = signInUseCase;
        private readonly IMapper mapper = mapper;

        [HttpPost("Login")]
        public IActionResult Login([FromBody] SignInDTO login)
        {
            var input = mapper.Map<InputSignIn>(login);
            var authentication = signInUseCase.Execute(input);
            return Ok(mapper.Map<ResponseAuthDTO>(authentication));
        }
    }
}
