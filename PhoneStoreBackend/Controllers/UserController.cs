using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PhoneStoreBackend.Data;
using PhoneStoreBackend.Models;
using PhoneStoreBackend.Models.DTOs;
using PhoneStoreBackend.Services;

namespace PhoneStoreBackend.Controllers
{
    [ApiController]
    [EnableCors("AllowAll")]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly IMapper _mapper;

        private readonly UserService _userService;

        public UserController(ILogger<UserController> logger, IMapper mapper, UserService userService)
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<string>> SignUp(UserDTO userDTO)
        {
            _logger.LogInformation($"Регистрирую пользователя - {userDTO.UserName}");
            return await _userService.SignUp(_mapper.Map<User>(userDTO));
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<string>> SignIn(UserDTO userDTO)
        {
            return await _userService.SignIn(_mapper.Map<User>(userDTO));
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<User>>> GetUser()
        {
            return await _userService.GetUsers();
        }

        [Authorize]
        [HttpGet("GetRole")]
        public async Task<ActionResult<Role>> Roles(int id)
        {
            return await _userService.GetRoles(id);
        }

        [HttpGet("Test")]
        public async Task<ActionResult<string>> Test()
        {
            return "Test";
        }

    }
}
