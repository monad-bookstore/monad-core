using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Application.Helpers;
using Application.Models;
using Application.Models.Types;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using BCrypt.Net;

namespace Application.Services
{
    public interface IClientService
    {
        Client Authenticate(string username, string password);
    }

    public class ClientService : IClientService
    {
        private readonly ApplicationSettings _settings;
        private readonly BookstoreContext _context;

        public ClientService(IOptions<ApplicationSettings> settings, BookstoreContext context)
        {
            _settings = settings.Value;
            _context = context;
        }

        public Client Authenticate(string username, string password)
        {
            Client client = _context.Clients.SingleOrDefault(_ => _.Username == username);

            if (client == null)
                return null;

            if (!BCrypt.Net.BCrypt.Verify(password, client.Password))
                return null;
            
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_settings.Secret);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, client.Id.ToString()), 
                    new Claim(ClaimTypes.Role, Enum.GetName(typeof(AccessType), client.AccessFlag)),
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken authorizationKey = handler.CreateToken(descriptor);
            client.AuthorizationKey = handler.WriteToken(authorizationKey);
            client.Password = null;
            return client;
        }
    }
}