namespace License.viewer.api.Users.Infrastructure
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using License.viewer.api.Models;
    using License.viewer.api.Users.Application;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;

    [ApiController]
    [Route("login")]
    public class UserController : ControllerBase
    {
        private readonly Jwt _jwt;
        private readonly UsersSearcher _searcher;
        private readonly IUserRepository _userRepository;

        public UserController(Jwt jwt, UsersSearcher searcher, IUserRepository userRepository)
        {
            this._jwt = jwt;
            this._searcher = searcher;
            this._userRepository = userRepository;
        }

        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            List<User> users = await this._searcher.Execute(request.User, request.Password);
            if (users.Count == 0)
            {
                return this.NotFound();
            }

            User user = users[0];
            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, this._jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, DateTime.UtcNow.ToString()),
                new Claim("id", user.IdUser),
                new Claim("user", user.IdUser)
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(this._jwt.Key));
            SigningCredentials signIn = new(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(
                this._jwt.Issuer,
                this._jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: signIn);

            LoginResponse userData = new(
                new JwtSecurityTokenHandler().WriteToken(token),
                user.Name,
                user.IdUser,
                user.Email,
                user.Rol,
                user.Address,
                user.Phone,
                user.BirthDate);

            return this.Ok(userData);
        }

        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            // Aquí puedes validar y realizar otras operaciones antes de guardar el usuario

            User newUser = new User(
                iduser: null,
                nameuser: request.NameUser,
                password: request.Password,
                name: request.Name,
                email: request.Email,
                rol: request.Role,
                address: request.Address,
                phone: request.Phone,
                birthDate: request.BirthDate

            );

            await _userRepository.Save(newUser);

            return Ok(newUser);
        }
    }
}

public sealed record LoginRequest(string User, string Password);

public sealed record LoginResponse(string Token, string Name, string UserId, string Email, string Role, string address, string phone, DateTime birthDate);


