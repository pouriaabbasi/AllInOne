using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AllInOne.Data;
using AllInOne.Data.Entity.Security;
using AllInOne.Models.Security;
using AllInOne.Services.Contract.Security;
using Microsoft.IdentityModel.Tokens;

namespace AllInOne.Services.Implementation.Security
{
    public class UserLib : IUserLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<User> userRepo;

        public UserLib(
            IUnitOfWork unitOfWork, 
            IRepository<User> userRepo)
        {
            this.unitOfWork = unitOfWork;
            this.userRepo = userRepo;
        }

        public UserModel Login(LoginModel model)
        {
            var user = userRepo.First(x =>
                x.Username == model.Username
                && x.Password == model.Password);

            if (user == null) throw new Exception("Username or Password is not valid");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("AllInOneDeveloperJwtKey");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, user.Id.ToString())
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
    }
}