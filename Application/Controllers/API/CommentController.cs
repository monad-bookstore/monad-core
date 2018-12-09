using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Models.Specifics;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Controllers.API
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerContext
    {
        public CommentController(BookstoreContext context, IMapper mapper) : base(context, mapper) { }

        [Authorize]
        [Route("create")]
        [HttpPost]
        public IActionResult CreateComment(CommentCreationData request)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            Client client = GetClient();
            if (client == null) {
                return Unauthorized();
            }

            Book book = _context.Books
                .SingleOrDefault(c => c.Id == request.BookId);
            if (book == null) {
                return BadRequest();
            }
            
            _context.Comments.Add(new Comment
            {
                Message = request.Message,
                ClientId = client.Id,
                BookId = book.Id
            });

            _context.SaveChanges();
            return Ok();
        }

    }
}