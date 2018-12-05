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

namespace Application.Controllers.API
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingController : ControllerContext
    {
        public RatingController(BookstoreContext context, IMapper mapper) : base(context, mapper) { }

        [Authorize]
        [Route("rate")]
        [HttpPost]
        public void Rate(RatingData request)
        {
            if (!ModelState.IsValid)
                return;

            Client client = GetClient();
            if (client == null)
                return;

            int rated = _context.Ratings.Count(c => c.BookId == request.BookId && c.ClientId == client.Id);
            if (rated > 0)
                return;

            if (request.Rating > 5 || request.Rating < 0)
                return;

            _context.Ratings.Add(new Rating
            {
                ClientId = client.Id,
                BookId = request.BookId,
                Rating1 = request.Rating
            });

            _context.SaveChanges();
        }
    }
}