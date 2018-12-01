using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

            client.Email = email ?? client.Email;
            _context.SaveChanges();
        }

        [Authorize]
        [Route("modify/password")]
        [HttpPost]
        public void ModifyClientPassword(dynamic request)
        {
            Client client = GetClient();
            if (client == null)
                return;

            client.Password = BCrypt.Net.BCrypt.HashPassword(request.password.ToString()) ?? client.Password;
            _context.SaveChanges();
        }
    }
}