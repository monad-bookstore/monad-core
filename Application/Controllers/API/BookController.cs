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
using Microsoft.EntityFrameworkCore;

namespace Application.Controllers.API
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerContext
    {
        [Authorize]
        [Route("get")]
        public IQueryable<BookDTO> FetchBookList()
        {
            return _context.Books
                .Include(x => x.BookAuthors)
                .Select(x => new BookDTO
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Title = x.Title,
                    CoverUrl = x.CoverUrl,
                    Price = x.Price,
                    Description = x.Description,
                    Pages = x.Pages,
                    Authors = x.BookAuthors.Select(c => c.AuthorId).ToList()
                });
        }
        public BookController(BookstoreContext context, IMapper mapper) : base(context, mapper) {}
    }
}