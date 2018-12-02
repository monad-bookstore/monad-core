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

        [Authorize(Roles = "Administrator,Manager")]
        [Route("create")]
        public IActionResult CreateBook(BookCreationData request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Book created = new Book
            {
                Title = request.Title,
                CategoryId = request.CategoryId,
                Pages = request.Pages,
                CoverUrl = request.Cover,
                Price = request.Price,
                Description = request.Description
            };

            request.Authors.ForEach(authorId =>
            {
                Author author = _context.Authors.SingleOrDefault(x => x.Id == authorId);
                if (author != null)
                {
                    created.BookAuthors.Add(new BookAuthor
                    {
                        AuthorId = authorId,
                        BookId = created.Id
                    });
                }
            });

            _context.Books.Add(created);
            _context.SaveChanges();
            return Ok(new
            {
                message = "Nauja knyga sukurta."
            });
        }
    }
}