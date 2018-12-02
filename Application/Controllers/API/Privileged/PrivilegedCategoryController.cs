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

namespace Application.Controllers.API.Privileged
{
    [Route("api/privileged/categories")]
    [ApiController]
    public class PrivilegedCategoryController : ControllerContext
    {
        public PrivilegedCategoryController(BookstoreContext context, IMapper mapper) : base(context, mapper) { }

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

    }
}