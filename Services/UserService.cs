using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataModels;
using Models;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Services
{
    public class UserService:IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IOptions<AppSettings> _options;

        public UserService(IRepository<User> userRepository, IOptions<AppSettings> options)
        {
            _userRepository = userRepository;
            _options = options;
            
        }

        public UserModel Authenticate(string username, string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            var user = _userRepository.GetAll().SingleOrDefault(x =>
                x.Username == username && x.Password == hashedPassword);

            if (user == null) return null;
            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),



                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = TokenHandler.CreateToken(tokenDescriptor);
            var userModel = new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username=user.Username,
                Token = TokenHandler.WriteToken(token)
            };

            return userModel;
        
    }

        public void Register(RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword)
                throw new Exception("Password mismatch!");

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(model.Password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = hashedPassword
            };

            _userRepository.Add(user);
        }
    }
}
