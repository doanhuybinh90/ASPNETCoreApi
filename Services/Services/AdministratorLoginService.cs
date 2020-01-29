using Domain.Entities;
using Domain.Interfaces;
using Domain.Repository;
using Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AdministratorLoginService : IAdministratorLoginService
    {
        private IAdministratorRepository _repository;
        private SigningConfiguration _signingConfiguration;
        private TokenConfiguration _tokenConfiguration;
        private IConfiguration _configuration { get; }

        public AdministratorLoginService(IAdministratorRepository repository, SigningConfiguration signingConfiguration, TokenConfiguration tokenConfiguration, IConfiguration configuration)
        {
            _repository = repository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(Administrator administrator)
        {
            var baseUser = new Administrator();

            if (administrator != null && !string.IsNullOrWhiteSpace(administrator.Email))
            {
                baseUser = await _repository.FindByLogin(administrator.Email);
                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Authentication failed"
                    };
                }
                else
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(administrator.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //Jti O id do token
                            new Claim(JwtRegisteredClaimNames.UniqueName, administrator.Email),

                        });
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token, administrator);
                }
            }
            else
            {
                return null;
            }
        }
        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }
        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, Administrator administrator)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = administrator.Email,
                name = administrator.Name,
                message = "Logged in"
            };
        }
    }
}
