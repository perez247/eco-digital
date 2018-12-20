using System.Threading.Tasks;
using AutoMapper;
using Code.Controllers.Resources.Http.RequestResources;
using Code.Controllers.Resources.Http.ResponseResources;
using Code.Core.Interfaces;
using Code.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Code.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _auth;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository auth, IMapper mapper)
        {
            _auth = auth;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestResource loginRequestResource)
        {
            var user = await _auth.Login(loginRequestResource.EmailUsername, loginRequestResource.Password);
            if(user == null)
                return Unauthorized();

            var userResponseResource = _mapper.Map<UserResponseResource>(user);
            
            // return Ok(new {token =  Functions.generateUserToken(user,_config), user = userResponseResource });
            return Ok(loginRequestResource);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestResource registerRequestResource)
        {
            var user = _mapper.Map<User>(registerRequestResource);
            user = await _auth.Register(user, registerRequestResource.Password);

            var userResponseResource = _mapper.Map<UserResponseResource>(user);
            
            // return Ok(new {token =  Functions.generateUserToken(user,_config), user = userResponseResource });
            return Ok(userResponseResource);
        }
    }
}