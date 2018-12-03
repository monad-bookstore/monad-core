using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Controllers.API
{
    [Route("api/phone")]
    [ApiController]
    public class PhoneNumberController : ControllerContext
    {
        public PhoneNumberController(BookstoreContext context, IMapper mapper) : base(context, mapper) {}

        [Route("remove/{numberId}")]
        public IActionResult Remove(int numberId)
        {
            PhoneNumber removing = _context
                .PhoneNumbers
                .Include(c => c.Addresses)
                .SingleOrDefault(c => c.ClientId == GetClient().Id && c.Id == numberId);

            if (removing == null)
            {
                return BadRequest(new
                {
                    message = "Šis tel. numeris neegzistuoja."
                });
            }

            if (removing.Addresses.Count > 0)
            {
                return BadRequest(new
                {
                    message = "Šis tel. numeris yra priskirtas prie adreso, todėl jo ištrinti negalima."
                });
            }

            _context.PhoneNumbers.Remove(removing);
            _context.SaveChanges();
            return Ok(new
            {
                message = "Tel. numeris ištrintas!"
            });
        }

        [Route("modify/{id}")]
        [HttpPost]
        public IActionResult Modify(int id, PhoneNumberDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Client client = GetClient();
            if (client == null)
                return Unauthorized();

            PhoneNumber number = _context
                .PhoneNumbers
                .SingleOrDefault(c => c.Id == id && c.ClientId == client.Id);

            if (number == null)
            {
                return BadRequest(new
                {
                    message = "Toks tel. numeris neegzistuoja."
                });
            }

            if (number.Label != request.Label)
                number.Label = request.Label;

            if (number.Number != request.Number)
                number.Number = request.Number;

            _context.SaveChanges();
            return Ok(new
            {
                message = "Tel. numeris pakeistas."
            });
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(PhoneNumberDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Client client = GetClient();
            if (client == null)
                return Unauthorized();

            _context
                .PhoneNumbers
                .Add(new PhoneNumber
                {
                    Label = request.Label,
                    Number = request.Number,
                    ClientId = client.Id
                });

            _context.SaveChanges();
            return Ok(new
            {
                message = "Naujas tel. numeris sukurtas."
            });
        }
    }
}