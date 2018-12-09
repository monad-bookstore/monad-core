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

namespace Application.Controllers.API
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerContext
    {
        public OrderController(BookstoreContext context, IMapper mapper) : base(context, mapper) { }

        [Authorize]
        [Route("get")]
        public IQueryable<OrderExpanded> FetchOrderList()
        {
            Client client = GetClient();
            if (client == null) {
                return null;
            }

            return _context.Orders
                .Include(o => o.Ordered)
                .ThenInclude(o => o.Book)
                .ThenInclude(o => o.BookAuthors)
                .Include(o => o.Address)
                .Where(o => o.ClientId == client.Id)
                .Select(c => new OrderExpanded
                {
                    Id = c.Id,
                    Client = null,
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


        [Authorize]
        [Route("get/{orderId}")]
        public IActionResult Get(int orderId)
        {
            Client client = GetClient();
            if (client == null) {
                return Unauthorized();
            }

            OrderExpanded order = _context.Orders
                .Include(o => o.Ordered)
                .ThenInclude(o => o.Book)
                .ThenInclude(o => o.BookAuthors)
                .Include(o => o.Address)
                .Where(o => o.Id == orderId && o.ClientId == client.Id)
                .Select(c => new OrderExpanded
                {
                    Id = c.Id,
                    Client = null,
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
                }).FirstOrDefault();

            if (order == null)
            {
                return BadRequest(new
                {
                    message = "Užsakymas tokiu ID nerastas."
                });
            }

            return Ok(order);
        }

        [Authorize]
        [Route("create")]
        [HttpPost]
        public IActionResult Create(OrderCreationData request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Client client = GetClient();
            if (client == null)
            {
                return Unauthorized();
            }

            int orders = _context.Orders
                .Count(c => c.Id == client.Id && c.Status != 4);

            if (orders >= 5)
            {
                return BadRequest(new
                {
                    message = "Vienu metu klientams leidžiama turėti maksimaliai 5 vykdomus užsakymus."
                });
            }

            Order order = new Order
            {
                AddressId = request.AddressId,
                ClientId = client.Id
            };

            foreach (int bookId in request.Books)
            {
                Book book = _context.Books.SingleOrDefault(c => c.Id == bookId);
                if (book == null)
                {
                    return BadRequest(new
                    {
                        message = "Klaida kuriant užsakymą."
                    });
                }

                order.Ordered.Add(new Ordered
                {
                    BookId = book.Id,
                    OrderId = order.Id
                });
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
            return Ok(new
            {
                message = "Užsakymas sėkmingai sukurtas.",
                orderId = order.Id
            });
        }
    }
}