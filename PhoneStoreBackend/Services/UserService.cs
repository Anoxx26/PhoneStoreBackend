using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using PhoneStoreBackend.Data;
using PhoneStoreBackend.Models;
using PhoneStoreBackend.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace PhoneStoreBackend.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        private readonly RoleRepository _roleRepository;

        public UserService(UserRepository userRepository, RoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<string> SignUp(User user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Email))
                return "False";

            User us = await _userRepository.GetUserByUsername(user.UserName);

            if (us != null) return "False";

            us = await _userRepository.GetUserByEmail(user.Email);

            if (us != null) return "False";

            if (!IsValidEmail(user.Email)) return "False";

            List<User> users = await _userRepository.GetAllUsers();


            int newId = 0;
            if (users.Count > 0)
            {
                newId = users.OrderByDescending(x => x.UserId).FirstOrDefault().UserId + 1;
            }
            user.UserId = newId;

            user.RoleId = 1;

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _userRepository.AddUser(user);

            return "True";
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetAllUsers();
        }


        public async Task<Role> GetRoles(int id)
        {
            return await _roleRepository.GetRoleById(id);
        }

        public async Task<string> SignIn(User user)
        {
            
            var new_user = await _userRepository.GetUserByUsername(user.UserName);

            if (new_user == null) 
            {
                throw new SignInException("Пользователь не найден.");
            }

            if (new_user.UserName != user.UserName || BCrypt.Net.BCrypt.Verify(user.Password, new_user.Password) == false)
            {
                throw new SignInException("Неверный логин или пароль");
            }

            return await GenerateJwtToken(new_user);
        }

        public async Task<string> GenerateJwtToken(User user)
        {
            var userIdClaim = new Claim("userId", user.UserId.ToString());
            var roles = await _roleRepository.GetAllRoles();
            Role role = roles.FirstOrDefault(x => x.RoleId == user.RoleId);

            Console.WriteLine(role.RoleName);

            string roleName = role.RoleName;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("I_Love_Cat_Because_They_Cute2004");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, roleName),
                    userIdClaim,
                    // Добавьте другие нужные вам Claims
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$";
            Match match = Regex.Match(email, pattern);

            return match.Success;
        }

        public class SignInException : Exception
        {
            public SignInException(string message) : base(message)
            {
            }
        }
    }
}
