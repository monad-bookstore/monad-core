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
using OrderExpanded = Application.Models.Specifics.OrderExpanded;

namespace Application.Controllers.API.Privileged
{
    [Route("api/privileged/orders")]
    [ApiController]
    public class PrivilegedOrderController : ControllerContext
    {
        public PrivilegedOrderController(BookstoreContext context, IMapper mapper) : base(context, mapper) { }

        [Authorize]
        [Route("get")]
        public IQueryable<OrderExpanded> FetchOrderList()
        {
            return _context.Orders
                .Include(o => o.Client)
                .ThenInclude(o => o.Profiles)
                .Include(o => o.Ordered)
                .ThenInclude(o => o.Book)
                .ThenInclude(o => o.BookAuthors)
                .Include(o => o.Address)
                .Select(c => new OrderExpanded
                {
                    Id = c.Id,
                    Client = ClientExpanded.Create(c.Client, c.Client.Profiles.FirstOrDefault()),
                    Address = _mapper.Map<AddressDTO>(c.Address),
                    CreatedAt = c.CreatedAt,
                    Products = c.Ordered.Select(x => new BookDTO
                    {
                        Id = x.Book.Id,
                        CategoryId = x.Book.CategoryId,
                        Title = x.Book.Title,
                        CoverUrl = x.Book.CoverUrl,
                        Price = x.Book.Price,
                        Description = x.Book.Description,
                        Pages = x.Book.Pages,
                        Authors = x.Book.BookAuthors.Select(ctx => ctx.AuthorId).ToList()
                    }).ToList(),
                    Status = c.Status
                });
        }
    }
}