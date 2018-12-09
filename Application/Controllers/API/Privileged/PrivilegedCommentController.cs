using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.API.Privileged
{
    [Route("api/privileged/comments")]
    [ApiController]
    public class PrivilegedCommentController : ControllerContext
    {
        public PrivilegedCommentController(BookstoreContext context, IMapper mapper) : base(context, mapper) {}

        [Authorize(Roles = "Administrator,Manager,Support,Employee")]
        [Route("delete/{commentId}")]
        public void DeleteComment(int commentId)
        {
            if (GetClient() == null)
            {
                return;
            }

            var comment = _context.Comments
                .SingleOrDefault(c => c.Id == commentId);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
        }
    }
}