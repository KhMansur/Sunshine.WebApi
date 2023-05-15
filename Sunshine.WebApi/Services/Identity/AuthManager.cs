using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Sunshine.Data.Models;
using Sunshine.Service.DTOs;
using Sunshine.Service.IRepositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sunshine.WebApi.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private IConfiguration _configuration;
        private ApiUser _user;
        private IStudentRepository _studentRepository;
        private IMapper _mapper;

        public AuthManager(UserManager<ApiUser> userManager,
                IConfiguration configuration,
                IMapper mapper,
                IStudentRepository studentRepository)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }
        public async Task<string> CreateToken()
        {
            var signInCredentials = GetSignInCredentials();

            var claims = await GetClaims();

            var token = GenerateTokenOptions(signInCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> ValidateUser(LoginDto dto)
        {
            _user = await _userManager.FindByNameAsync(dto.Username);

            var validPassword = await _userManager.CheckPasswordAsync(_user, dto.Password);

            return (_user != null && validPassword);
        }

        public async Task<Response> ValidateToken(string token)
        {
            if (token == null)
                return new Response { Message = "UnAuthorized", Status = "Invalid" };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Jwt").GetSection("Key").Value);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userName = jwtToken.Claims.FirstOrDefault().Value.ToString();
                var roles = _userManager.GetRolesAsync(await _userManager.FindByNameAsync(userName));
                if (userName != null)
                {
                    Response response = new Response()
                    {
                        Message = userName,
                        Status = "Valid"
                    };
                    foreach(var role in roles.Result)
                    {
                        response.Roles.Add(role);
                    }
                    // return user id from JWT token if validation successful
                    return response;
                }
                else
                {
                    return new Response { Message = userName, Status = "Invalid" };
                }
            }
            catch
            {
                // return null if validation fails
                return new Response { Message = "UnAuthorized", Status = "Invalid" };
            }
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signInCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var expiration = DateTime.Now.AddMinutes(
                Convert.ToDouble(
                    jwtSettings.GetSection("lifetime").Value));
            var token = new JwtSecurityToken(
                    issuer: jwtSettings.GetSection("Issuer").Value,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: signInCredentials
                );

            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, _user.UserName),
                new Claim("Id", _user.Id.ToString()),
                new Claim("Name", $"{_user.FirstName} {_user.LastName}")
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSignInCredentials()
        {

            var key = _configuration.GetSection("Jwt").GetSection("Key").Value;

            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<string> AddStudent(RegisterStudentDto dto)
        {
            var userExists = await _userManager.FindByNameAsync(dto.Username);
            if (userExists != null)
                return "User already exists!";
            ApiUser user = new ApiUser()
            {
                FirstName = dto.Firstname,
                LastName = dto.LastName,
                UserName = dto.Username,
                Email = dto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            var userr = await _userManager.FindByNameAsync(dto.Username);
            if (result.Succeeded)
            {
                var createRole = await _userManager.AddToRoleAsync(userr, "Student");
                if (!createRole.Succeeded)
                {
                    return "User creation failed! Please check user details and try again.";
                }
            }
            return "User created successfully!";
        }

        public async Task<string> AddTeacher(RegisterTeacherDto dto)
        {
            var userExists = await _userManager.FindByNameAsync(dto.Username);
            if (userExists != null)
                return "User already exists!";
            ApiUser user = new ApiUser()
            {
                FirstName = dto.Firstname,
                LastName = dto.LastName,
                UserName = dto.Username,
                Email = dto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            var userr = await _userManager.FindByNameAsync(dto.Username);
            if (result.Succeeded)
            {
                var createRole = await _userManager.AddToRoleAsync(userr, "Student");
                if (!createRole.Succeeded)
                {
                    return "User creation failed! Please check user details and try again.";
                }
            }
            return "User created successfully!";
        }
    }
}
