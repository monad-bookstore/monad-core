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
    }
}