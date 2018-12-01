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
using Profile = Application.Models.Profile;

namespace Application.Controllers.API
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerContext
    {
        public ProfileController(BookstoreContext context, IMapper mapper) : base(context, mapper) {}

        [Authorize]
        [Route("get")]
        [HttpGet]
        public IActionResult GetProfile()
        {
            Client client = GetClient();
            if (client == null)
                return Unauthorized();

            Profile profile = _context.Profiles
                .SingleOrDefault(c => c.ClientId == client.Id);

            if (profile != null)
            {
                return Ok(new
                {
                    success = true,
                    data = _mapper.Map<ProfileDTO>(profile)
                });
            }

            return Ok(new
            {
                success = false,
                data = new
                {
                    name = "",
                    surname = ""
                }
            });
        }

        [Authorize]
        [Route("modify")]
        [HttpPost]
        public void ModifyProfile(ProfileDTO data)
        {
            Client client = GetClient();
            if (client == null)
                return;

            Profile profile = _context.Profiles
                .SingleOrDefault(c => c.ClientId == client.Id);

            if (profile == null)
            {
                _context.Profiles.Add(new Profile
                {
                    ClientId = client.Id,
                    Name = data.Name ?? "",
                    Surname = data.Surname ?? ""
                });
            }
            else
            {
                if (!string.IsNullOrEmpty(data.Name))
                    profile.Name = data.Name;

                if (!string.IsNullOrEmpty(data.Surname))
                    profile.Surname = data.Surname;
            }

            _context.SaveChanges();
        }
    }
}