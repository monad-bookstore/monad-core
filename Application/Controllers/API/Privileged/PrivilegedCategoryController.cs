using System;
using System.Collections.Generic;
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
    [Route("api/privileged/categories")]
    [ApiController]
    public class PrivilegedCategoryController : ControllerContext
    {
        public PrivilegedCategoryController(BookstoreContext context, IMapper mapper) : base(context, mapper) { }

        [Authorize(Roles = "Administrator,Manager")]
        [Route("modify/{id}")]
        public IActionResult ModifyCategory(int id, CategoryCreationData request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category modifying = _context
                .Categories.SingleOrDefault(c => c.Id == id);

            if (modifying != null)
            {
                modifying.Label = request.Label;
                modifying.ParentId = request.ParentId == 0 || request.ParentId == null ? null : request.ParentId;
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [Authorize(Roles = "Administrator,Manager")]
        [Route("create")]
        public IActionResult CreateCategory(CategoryCreationData request)
        {
            int categories = _context.Categories
                .Count(c => c.Label == request.Label);

            if (categories > 0)
            {
                return BadRequest(new
                {
                    message = "Šiuo pavadinimu kategorija jau egzistuoja."
                });
            }

            _context.Categories.Add(new Category
            {
                Label = request.Label,
                ParentId = request.ParentId
            });

            _context.SaveChanges();
            return Ok(new
            {
                message = "Nauja kategorija sukurta."
            });
        }

        [Authorize(Roles = "Administrator,Manager")]
        [Route("remove/{id}")]
        public IActionResult RemoveAuthor(int id)
        {
            Category removing = _context
                .Categories
                .Include(c => c.Books)
                .SingleOrDefault(c => c.Id == id);

            if (removing != null)
            {
                _context.Categories.Remove(removing);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Kategorija ištrinta."
                });
            }

            return BadRequest();
        }
    }
}