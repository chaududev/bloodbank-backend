using Application.IService;
using Domain.Model.Base;
using Domain.Model.Posts;
using Domain.Model.Users;
using Infrastructure.IRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserService : IUserService
    {
        readonly IConfiguration Configuration;
		readonly IBaseRepository<User> repository;


		public UserService(IConfiguration configuration, IBaseRepository<User> repository)
        {
            this.Configuration = configuration;
			this.repository = repository;
		}


		public JWToken GenerateJwtToken(User user,string roleName)
        {

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Username", user.UserName),
                        new Claim(ClaimTypes.Role, roleName),
                    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiresIn = DateTime.UtcNow.AddSeconds(int.Parse((Configuration["Jwt:Expires"])));
            var token = new JwtSecurityToken(
                Configuration["Jwt:Issuer"],
                Configuration["Jwt:Audience"],
                claims,
                expires: expiresIn,
                signingCredentials: signIn) ;
            return new JWToken(new JwtSecurityTokenHandler().WriteToken(token), expiresIn);
        }
	}
}
