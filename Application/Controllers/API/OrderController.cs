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
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerContext
    {
        public OrderController(BookstoreContext context, IMapper mapper) : base(context, mapper) { }

        [Authorize]
        [Route("create")]
        [HttpPost]
        public IActionResult Create(OrderCreationData request)
        {
            Client client = GetClient();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
            return BadRequest(new
            {
                message = "Užsakymas sėkmingai sukurtas."
            });
        }
    }
}