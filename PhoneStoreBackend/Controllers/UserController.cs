using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneStoreBackend.Models;
using PhoneStoreBackend.Models.DTOs;
using PhoneStoreBackend.Services;

namespace PhoneStoreBackend.Controllers
{
    [ApiController]
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

        [HttpPost]
        public ActionResult<User> SignUp(UserDTO userDTO)
        {
            _logger.LogInformation($"Регистрирую пользователя - {userDTO.UserName}");
            return _mapper.Map<User>(userDTO);
        }
    }
}
