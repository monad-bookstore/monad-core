using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.API
{
    [Authorize]
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : ControllerContext
    {
        [Route("modify/{id}")]
        [HttpPost]
        public IActionResult Modify(int id, AddressDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Client client = GetClient();
            if (client == null)
                return Unauthorized();

            Address address = _context
                .Addresses
                .SingleOrDefault(c => c.Id == id && c.ClientId == client.Id);

            if (address == null)
            {
                return BadRequest(new
                {
                    message = "Toks adresas neegzistuoja."
                });
            }

            if (address.Label != request.Label)
                address.Label = request.Label;

            if (address.AddressText != request.AddressText)
                address.AddressText = request.AddressText;

            if (address.City != request.City)
                address.City = request.City;

            if (address.PhoneId != request.PhoneId)
                address.PhoneId = request.PhoneId;

            if (address.CountryId != request.CountryId)
                address.CountryId = request.CountryId;

            _context.SaveChanges();
            return Ok(new
            {
                message = "Adresas pakeistas."
            });
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(AddressDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Client client = GetClient();
            if (client == null)
                return Unauthorized();

            PhoneNumber number = _context.PhoneNumbers
                .SingleOrDefault(c => c.Id == request.PhoneId && c.ClientId == client.Id);

            Country country = _context.Countries
                .SingleOrDefault(c => c.Id == request.CountryId);

            if (number == null)
            {
                return BadRequest(new
                {
                    message = "Nurodytas tel. numeris neegzistuoja."
                });
            }

            if (country == null)
            {
                return BadRequest(new
                {
                    message = "Nurodyta šalis neaptarnaujama."
                });
            }

            _context
                .Addresses
                .Add(new Address
                {
                    Label = request.Label,
                    AddressText = request.AddressText,
                    City = request.City,
                    ClientId = client.Id,
                    PhoneId = number.Id,
                    CountryId = country.Id 
                });

            _context.SaveChanges();
            return Ok(new
            {
                message = "Naujas adresas sukurtas."
            });
        }

        [Route("remove/{addressId}")]
        public IActionResult RemoveAddress(int addressId)
        {
            Address removing = _context
                .Addresses
                .SingleOrDefault(c => c.ClientId == GetClient().Id && c.Id == addressId);

            if (removing == null)
            {
                return BadRequest(new
                {
                    message = "Šis adresas neegzistuoja."
                });
            }

            int orders = _context
                .Orders.Count(c => c.AddressId == removing.Id);

            if (orders > 0)
            {
                return BadRequest(new
                {
                    message = "Šis adresas yra priskirtas prie užsakymo, todėl jo ištrinti negalima."
                });
            }

            _context.Addresses.Remove(removing);
            _context.SaveChanges();
            return Ok(new
            {
                message = "Adresas ištrintas!"
            });
        }

        [Route("supported_country_list")]
        public IQueryable<CountryDTO> FetchCountryList()
        {
            return _context
                .Countries
                .Select(c => _mapper.Map<CountryDTO>(c));
        }

        public AddressController(BookstoreContext context, IMapper mapper) : base(context, mapper) {}
    }
}