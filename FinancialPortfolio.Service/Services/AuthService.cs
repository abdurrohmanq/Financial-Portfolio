using FinancialPortfolio.Data.IRepositories;
using FinancialPortfolio.Domain.Entities.Users;
using FinancialPortfolio.Service.Exceptions;
using FinancialPortfolio.Service.Helpers;
using FinancialPortfolio.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolio.Service.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User> repository;
    private readonly IConfiguration configuration;
    public AuthService(IRepository<User> repository, IConfiguration configuration)
    {
        this.repository = repository;
        this.configuration = configuration;
    }
    public async Task<string> GenerateTokenAsync(string phone, string password)
    {
        var user = await repository.GetAsync(u => u.Phone.Equals(phone));
        if(user is null)
             throw new NotFoundException("This user is not found");

        bool verifyPassword = PasswordHash.Verify(password,user.Password);
        if (!verifyPassword)
            throw new CustomException(400, "Phone or Password invalid");

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("Phone",user.Phone),
                new Claim("Id",user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        string result = tokenHandler.WriteToken(token);
        return result;
    }
}
