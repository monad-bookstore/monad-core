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
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerContext
    {
        public CategoryController(BookstoreContext context, IMapper mapper) : base(context, mapper) { }

        [Authorize]
        [Route("get")]
        public IQueryable<CategoryDTO> FetchCategoryList()
        {
            return _context.Categories
                .Select(x => _mapper.Map<CategoryDTO>(x));
        }
    }
}