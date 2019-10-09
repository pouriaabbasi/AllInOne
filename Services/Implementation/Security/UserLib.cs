using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Data;
using AllInOne.Data.Entity.Security;
using AllInOne.Models.Security;
using AllInOne.Services.Contract.Security;
using AllInOne.Services.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AllInOne.Services.Implementation.Security
{
    public class UserLib : IUserLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<User> userRepo;
        private readonly AppSettings appSettings;

        public UserLib(
            IUnitOfWork unitOfWork,
            IRepository<User> userRepo,
            IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
            this.unitOfWork = unitOfWork;
            this.userRepo = userRepo;
        }

        public async Task<UserModel> LoginAsync(LoginModel model)
        {
            var password = model.Password.HashPassword(model.Username);
            var user = await userRepo.FirstAsync(x =>
                x.Username == model.Username
                && x.Password == password);

            if (user == null) throw new Exception("Username or Password is not valid");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Sid, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Token = tokenHandler.WriteToken(token)
            };
        }

        public async Task<bool> RegisterAsync(RegisterModel model)
        {
            var userEntity = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = model.Password.HashPassword(model.Username)
            };

            await userRepo.AddAsync(userEntity);

            await unitOfWork.CommitAsync();

            return true;
        }
    }
}