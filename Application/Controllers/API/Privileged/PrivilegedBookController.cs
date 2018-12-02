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
    [Route("api/privileged/books")]
    [ApiController]
    public class PrivilegedBookController : ControllerContext
    {
        public PrivilegedBookController(BookstoreContext context, IMapper mapper) : base(context, mapper) {}

        [Authorize(Roles = "Administrator,Manager")]
        [Route("get")]
        public IQueryable<BookDTO> FetchBookList()
        {
            return _context.Books
                .Select(x => _mapper.Map<BookDTO>(x));
        }
    }
}