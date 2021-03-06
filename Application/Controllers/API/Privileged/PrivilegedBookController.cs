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

namespace Application.Controllers.API.Privileged
{
    [Route("api/privileged/books")]
    [ApiController]
    public class PrivilegedBookController : ControllerContext
    {
        public PrivilegedBookController(BookstoreContext context, IMapper mapper) : base(context, mapper) {}

        [Authorize(Roles = "Administrator,Manager")]
        [Route("modify/{id}")]
        public IActionResult Modify(int id, ProductExpanded request)
        {
            //
            Book modifying = _context.Books
                .Include(c => c.BookAuthors)
                .ThenInclude(c => c.Author)
                .Include(x => x.Ratings)
                .Include(x => x.Comments)
                .SingleOrDefault(c => c.Id == id);

            if (modifying == null)
                return BadRequest();

            modifying.Title = request.Title;
            List<int> currentAuthors = modifying.BookAuthors.Select(c => c.AuthorId).ToList();
            List<int> newAuthors = request.Authors.Select(c => c.Id).ToList();
            // Išimami nenurodyti autoriai
            foreach (int cai in currentAuthors)
            {
                if (!newAuthors.Contains(cai))
                {
                    BookAuthor modba = modifying.BookAuthors.SingleOrDefault(c => c.AuthorId == cai);
                    if (modba != null)
                    {
                        modifying.BookAuthors.Remove(modba);
                    }
                }
            }
            // Pridedami nauji autoriai
            foreach (int nai in newAuthors)
            {
                if (!currentAuthors.Contains(nai))
                {
                    modifying.BookAuthors.Add(new BookAuthor
                    {
                        AuthorId = nai,
                        BookId = modifying.Id
                    });
                }
            }

            modifying.CategoryId = request.CategoryId;
            modifying.CoverUrl = request.CoverUrl;
            modifying.Price = request.Price;
            modifying.Pages = request.Pages;
            modifying.Description = request.Description;
            foreach (var property in _context.Entry(modifying).Properties.Where(c => c.CurrentValue == null && c.IsModified))
                property.IsModified = false;

            modifying.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return Ok();
        }
        
        [Authorize(Roles = "Administrator,Manager")]
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

        [Authorize(Roles = "Administrator,Manager")]
        [Route("remove/{id}")]
        public IActionResult RemoveBook(int id)
        {
            Book removing = _context.Books
                .Include(c => c.BookAuthors)
                .ThenInclude(c => c.Author)
                .Include(x => x.Ratings)
                .Include(x => x.Comments)
                .SingleOrDefault(c => c.Id == id);

            if (removing == null)
                return Ok();

            _context.Books.Remove(removing);
            _context.SaveChanges();
            return Ok();
        }
    }
}