using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Models.DTOs;
using Application.Services;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public AuthenticationController(IClientService clientService, BookstoreContext context, IMapper mapper)
        {
            _client = clientService;
            _context = context;
            _mapper = mapper;
        }

        [Authorize]
        [Route("client")]
        public IActionResult Client()
        {
            Client client = _context
                .Clients
                .SingleOrDefault(c => c.Id.ToString() == User.Identity.Name);

            if (client == null)
                return Unauthorized();

            return Ok(_mapper.Map<ClientDTO>(client));
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