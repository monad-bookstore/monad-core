using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Controllers.API
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly BookstoreContext _context;

        public ClientController(BookstoreContext context)
        {
            _context = context;
        }
    }
}