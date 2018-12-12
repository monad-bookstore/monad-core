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
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerContext
    {
        [Authorize]
        [Route("get")]
        public IQueryable<AuthorDTO> FetchAuthorsList()
        {
            return _context.Authors
                .Select(x => _mapper.Map<AuthorDTO>(x));
        }

        public AuthorController(BookstoreContext context, IMapper mapper) : base(context, mapper)
        {}
    }
}