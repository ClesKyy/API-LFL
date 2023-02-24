using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjetApiLFL.Dtos.User;
using ProjetApiLFL.Models;
using ProjetApiLFL.Repositories;
using ProjetApiLFL.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetApiLFL.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IOptionsSnapshot<JwtSettings> _jwtSettings;
        public AuthController(UserManager<User> userManager, RoleManager<Role> roleManager, IOptionsSnapshot<JwtSettings> jwtSettings, IUserRepository userRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings;
            _userRepository = userRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_userRepository.GetUsers());

        }
        [HttpPost("signup")]

        public async Task<IActionResult> SignUp([FromBody] UserSignUpDto userSignUpDto)
        {
            var user = new User
            {
                Pseudo = userSignUpDto.Pseudo,
                UserName = userSignUpDto.Pseudo,
                Password = userSignUpDto.Password,
               
            };
            var userCreateResult = await _userManager.CreateAsync(user, userSignUpDto.Password);
            if (userCreateResult.Succeeded)
            {
                return Created(string.Empty, string.Empty);
            }

            await _userManager.AddToRoleAsync(user, "User");

            return Problem(userCreateResult.Errors.First().Description, null, 400);
        }

        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("Le role doit avoir un nom");
            }
            var newRole = new Role
            {
                Name = roleName
            };
            var roleResult = await _roleManager.CreateAsync(newRole);
            if (roleResult.Succeeded)
            {
                return Ok();
            }
            return Problem(roleResult.Errors.First().Description, null, 500);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Pseudo == userLoginDto.Pseudo);
            if(user == null)
            {
                return NotFound("L'utilisateur n'existe pas");
            }
            var userLoginResult = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);
            if (userLoginResult)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(new
                {
                    token = GenerateJwt(user, roles)
                });
            }
            return BadRequest("Mot de passe incorrect");
        }
        private string GenerateJwt(User user, IList<string> roles)
        {
            var claims = new List<Claim>

            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),

                new Claim(ClaimTypes.Name, user.UserName),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())

            };



            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));

            claims.AddRange(roleClaims);



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.Value.ExpirationInDays));



            var token = new JwtSecurityToken(

                issuer: _jwtSettings.Value.Issuer,

                audience: _jwtSettings.Value.Issuer,

                claims,

                expires: expires,

                signingCredentials: creds

            );



            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
