using Microsoft.AspNetCore.Mvc;
using SlotEase.Application.DTOs.Auth;
using SlotEase.Application.Interfaces;

namespace SlotEase.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto dto)
        {
            var user=await _authService.RegisterAsync(dto);
            return Created($"/api/users/{user.Id}", user);
        }
    }
}
