﻿using System;
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
                .Select(x => new ProductExpanded
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Title = x.Title,
                    CoverUrl = x.CoverUrl,
                    Price = x.Price,
                    Description = x.Description,
                    Pages = x.Pages,
                    Authors = x.BookAuthors.Select(c => _mapper.Map<AuthorDTO>(c.Author)).ToList()
                });
        }

        public StoreController(BookstoreContext context, IMapper mapper) : base(context, mapper) {}
    }
}