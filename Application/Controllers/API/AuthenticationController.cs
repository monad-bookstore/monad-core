using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.API
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IClientService _client;
        private readonly BookstoreContext _context;

        public AuthenticationController(IClientService clientService, BookstoreContext context)
        {
            _client = clientService;
            _context = context;
        }

        [Authorize]
        [Route("client")]
        public IActionResult Client()
        {
            var cid = Convert.ToInt32(HttpContext.User.Identity.Name);
            Client client = _context.Clients.SingleOrDefault(c => c.Id == cid);
            if (client == null)
                return Unauthorized();

            client.Password = null;
            return Ok(client);
        }

        [Route("validate")]
        [HttpPost]
        public IActionResult Authenticate(Client data)
        {
            Client client = _client.Authenticate(data.Username, data.Password);
            if (client == null)
                return BadRequest(new {message = "Neteisingas vartotojo vardas arba slaptažodis."});

            return Ok(client);
        }
    }
}