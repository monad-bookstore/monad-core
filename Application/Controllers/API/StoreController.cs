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
using Microsoft.EntityFrameworkCore;

namespace Application.Controllers.API
{
    [Route("api/store")]
    [ApiController]
    public class StoreController : ControllerContext
    {
        
        [Authorize]
        [Route("products")]
        public IQueryable<ProductExpanded> FetchProductList()
        {
            return _context.Books
                .Include(x => x.BookAuthors)
                .ThenInclude(x => x.Author)
                .Include(x => x.Ratings)
                .Include(x => x.Comments)
                .Select(x => new ProductExpanded
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Title = x.Title,
                    CoverUrl = x.CoverUrl,
                    Price = x.Price,
                    Description = x.Description,
                    Pages = x.Pages,
                    Ratings = x.Ratings.Select(c => _mapper.Map<RatingDTO>(c)).ToList(),
                    Comments = x.Comments.Select(c => _mapper.Map<CommentDTO>(c)).ToList(),
                    Authors = x.BookAuthors.Select(c => _mapper.Map<AuthorDTO>(c.Author)).ToList()
                });
        }
        
        [Authorize]
        [Route("product/{id}")]
        public ProductExpanded GetProduct(int id)
        {
            return _context.Books
                .Include(x => x.BookAuthors)
                .ThenInclude(x => x.Author)
                .Include(x => x.Ratings)
                .Include(x => x.Comments)
                .Select(x => new ProductExpanded
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Title = x.Title,
                    CoverUrl = x.CoverUrl,
                    Price = x.Price,
                    Description = x.Description,
                    Pages = x.Pages,
                    Ratings = x.Ratings.Select(c => _mapper.Map<RatingDTO>(c)).ToList(),
                    Comments = x.Comments.Select(c => _mapper.Map<CommentDTO>(c)).ToList(),
                    Authors = x.BookAuthors.Select(c => _mapper.Map<AuthorDTO>(c.Author)).ToList()
                })
                .SingleOrDefault(c => c.Id == id);
        }

        public StoreController(BookstoreContext context, IMapper mapper) : base(context, mapper) {}
    }
}