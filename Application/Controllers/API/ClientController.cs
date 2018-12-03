using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Application.Models.DTOs;
using Application.Models.Specifics;
using BCrypt.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Controllers.API
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerContext
    {
        public ClientController(BookstoreContext context, IMapper mapper) : base(context, mapper) {}

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public IActionResult Register(RegisterClientData request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int mails = _context.Clients.Count(c => c.Email == request.Mail);
            int usernames = _context.Clients.Count(c => c.Username == request.Username);

            if (usernames > 0)
            {
                return BadRequest(new
                {
                    Username = new List<string> { "Vartotojo vardas užimtas." } 
                });
            }


            if (mails > 0)
            {
                return BadRequest(new
                {
                    Mail = new List<string> { "Vartotojas šiuo el. paštu jau registruotas." }
                });
            }

            _context.Clients.Add(new Client
            {
                Username = request.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Email = request.Mail,
                AccessFlag = 0
            });

            _context.SaveChanges();
            return Ok(new { message = "Nauja paskyra sėkmingai sukurta. Galite prisijungti." });
        }

        [Authorize]
        [Route("addresses")]
        [HttpGet]
        public IQueryable<AddressDTO> FetchClientAddresses()
        {
            return _context
                .Addresses
                .Where(c => c.ClientId == GetClient().Id)
                .Select(c => _mapper.Map<AddressDTO>(c));
        }

        [Authorize]
        [Route("numbers")]
        [HttpGet]
        public IQueryable<PhoneNumberDTO> FetchClientPhoneNumbers()
        {
            return _context
                .PhoneNumbers
                .Where(c => c.ClientId == GetClient().Id)
                .Select(c => _mapper.Map<PhoneNumberDTO>(c));
;        }

        [Authorize]
        [Route("modify/mail")]
        [HttpPost]
        public void ModifyClientEmail(dynamic request)
        {
            Client client = GetClient();
            if (client == null)
                return;

            string email = request.email.ToString();
            if (string.IsNullOrEmpty(email))
                return;

            client.Email = email;
            _context.SaveChanges();
        }

        [Authorize]
        [Route("modify/password")]
        [HttpPost]
        public IActionResult ModifyClientPassword(PasswordModify data)
        {
            Client client = GetClient();
            if (client == null)
                return Unauthorized();

            if (string.IsNullOrEmpty(data.Password))
                return BadRequest(new { message = "Blogas slaptažodis." });

            if (!BCrypt.Net.BCrypt.Verify(data.CurrentPassword, client.Password))
                return BadRequest(new { message = "Neteisingas dabartinis slaptažodis." });

            client.Password = BCrypt.Net.BCrypt.HashPassword(data.Password);
            _context.SaveChanges();
            return Ok(new { message = "Slaptažodis atnaujintas." });
        }
    }
}