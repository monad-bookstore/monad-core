using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Application.Models.Specifics;
using BCrypt.Net;
using AutoMapper;

namespace Application.Controllers.API
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerContext
    {
        public ClientController(BookstoreContext context, IMapper mapper) : base(context, mapper) {}

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