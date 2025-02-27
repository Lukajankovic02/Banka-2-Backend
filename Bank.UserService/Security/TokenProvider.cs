﻿using System.Security.Claims;
using System.Text;

using Bank.UserService.Application;
using Bank.UserService.Models;

using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Bank.UserService.Security;

public class TokenProvider
{
    public string Create(User user)
    {
        var expirationInMinutes = Convert.ToInt32(Environment.GetEnvironmentVariable(EnvironmentVariable.ExpirationInMinutes) ?? EnvironmentVariable.ExpirationInMinutesElseValue);
        var secretKey           = Environment.GetEnvironmentVariable(EnvironmentVariable.SecretKey) ?? EnvironmentVariable.SecretKeyElseValue;
        var securityKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
                     {
                         new("id", user.Id.ToString()),
                         new("role", user.Role.ToString())
                     };

        var tokenDescriptor = new SecurityTokenDescriptor
                              {
                                  Subject            = new ClaimsIdentity(claims),
                                  Expires            = DateTime.Now.AddMinutes(expirationInMinutes),
                                  SigningCredentials = credentials
                              };

        var handler = new JsonWebTokenHandler();

        return handler.CreateToken(tokenDescriptor);
    }

    public static string GenerateToken(User user)
    {
        var expirationInMinutes = Convert.ToInt32(Environment.GetEnvironmentVariable(EnvironmentVariable.ExpirationInMinutes) ?? EnvironmentVariable.ExpirationInMinutesElseValue);
        var secretKey           = Environment.GetEnvironmentVariable(EnvironmentVariable.SecretKey) ?? EnvironmentVariable.SecretKeyElseValue;
        var securityKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
                     {
                         new("id", user.Id.ToString()),
                         new("role", user.Role.ToString())
                     };

        var tokenDescriptor = new SecurityTokenDescriptor
                              {
                                  Subject            = new ClaimsIdentity(claims),
                                  Expires            = DateTime.Now.AddMinutes(expirationInMinutes),
                                  SigningCredentials = credentials
                              };

        var handler = new JsonWebTokenHandler();

        return handler.CreateToken(tokenDescriptor);
    }
}
