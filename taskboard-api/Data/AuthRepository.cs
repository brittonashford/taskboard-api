using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using taskboard_api.DTOs.Issue;
using taskboard_api.DTOs.User;
using taskboard_api.DTOs.UserRole;

namespace taskboard_api.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthRepository(DataContext context, IConfiguration config, IMapper mapper)
        {
            _context = context;
            _config = config;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var serviceResponse = new ServiceResponse<string>();
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());

            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Incorrect username or password.";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Unable to verify user with provided credentials.";
            }
            else
            {
                serviceResponse.Data = CreateToken(user);
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<int>> Register(User user, string password, string requestedRole)
        {
            var regResponse = new ServiceResponse<int>();
            var roleResponse = new ServiceResponse<UserRole>();

            if(await UserExists(user.Username))
            {
                regResponse.Success = false;
                regResponse.Message = "User already exists.";
                return regResponse;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            roleResponse = await FindUserRole(requestedRole);
            if(roleResponse.Data == null)
            {
                roleResponse.Success = false;
                roleResponse.Message = "Invalid UserRole";
                regResponse.Success = false;
                regResponse.Message = "Valid user role required.";
                return regResponse;
            }

            UserRole userRole = roleResponse.Data;
            user.UserRole = userRole;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            regResponse.Data = user.Id;

            return regResponse;
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
            {
                return true;
            }

            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<ServiceResponse<User>> GetUser(int userID)
        {
            var serviceResponse = new ServiceResponse<User>();
            var user = await _context.Users.FindAsync(userID);

            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"User not found. UserId: {userID}.";
                return serviceResponse;
            }

            serviceResponse.Data = user;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserRoleDTO>> GetUserRole(int userID)
        {
            var serviceResponse = new ServiceResponse<GetUserRoleDTO>();
            var user = await _context.Users.FindAsync(userID);

            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"User not found. UserId: {userID}.";
                return serviceResponse;
            }

            var userRole = _mapper.Map<GetUserRoleDTO>(user.UserRole);
            serviceResponse.Data = userRole;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserRoleDTO>>> GetAllUserRoles()
        {
            var serviceResponse = new ServiceResponse<List<GetUserRoleDTO>>();

            try
            {
                List<UserRole> userRoles = new List<UserRole>();
                userRoles = await _context.UserRoles.ToListAsync();
                serviceResponse.Data = userRoles.Select(r => _mapper.Map<GetUserRoleDTO>(r)).ToList();
            }
            catch (Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = "UserRoles not found";             
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserRole>> FindUserRole(string requestedRole)
        {
            var serviceResponse = new ServiceResponse<UserRole>();
            try
            {
                var userRole = await _context.UserRoles.FirstAsync(u => u.RoleType == requestedRole);
                serviceResponse.Data = _mapper.Map<UserRole>(userRole);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Invalid user role";
            }

            return serviceResponse;
        }
    }
}
