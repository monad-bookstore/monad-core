using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Models.DTOs;
using Application.Models.Specifics;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Controllers.API.Privileged
{
    [Route("api/privileged/authors")]
    [ApiController]
    public class PrivilegedAuthorsController : ControllerContext
    {
        public PrivilegedAuthorsController(BookstoreContext context, IMapper mapper) : base(context, mapper) {}

        [Authorize(Roles = "Administrator,Manager")]
        [Route("get")]
        public IQueryable<AuthorDTO> FetchAuthorsList()
        {
            return _context.Authors
                .Select(x => _mapper.Map<AuthorDTO>(x));
        }

        [Authorize(Roles = "Administrator,Manager")]
        [Route("create")]
        [HttpPost]
        public IActionResult CreateAuthor(AuthorCreationData request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context
                .Authors
                .Add(new Author()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    BirthDate = request.Birth,
                    DeathDate = request.Death
                });

            _context.SaveChanges();
            return Ok(new
            {
                message = "Naujas autorius sukurtas."
            });
        }

        [Authorize(Roles = "Administrator,Manager")]
        [Route("remove/{id}")]
        public IActionResult RemoveAuthor(int id)
        {
            Author removing = _context
                .Authors
                .Include(c => c.BookAuthors)
                .ThenInclude(c => c.Book)
                .SingleOrDefault(c => c.Id == id);

            if (removing != null)
            {
                _context.Authors.Remove(removing);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Autorius ištrintas."
                });
            }

            return BadRequest();
        }

        [Authorize(Roles = "Administrator,Manager")]
        [Route("modify/{id}")]
        [HttpPost]
        public IActionResult ModifyAuthor(int id, AuthorCreationData request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Author existing = _context.Authors
                .SingleOrDefault(c => c.Id == id);

            if (existing != null)
            {
                existing.Name = request.Name;
                existing.Surname = request.Surname;
                existing.BirthDate = request.Birth;
                existing.DeathDate = request.Death;
                foreach (var property in _context.Entry(existing).Properties.Where(c => c.CurrentValue == null && c.IsModified))
                    property.IsModified = false;
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }
    }
}