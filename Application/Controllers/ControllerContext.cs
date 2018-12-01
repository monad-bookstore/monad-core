using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public abstract class ControllerContext : ControllerBase
    {
        protected readonly BookstoreContext _context;
        protected readonly IMapper _mapper;

        protected ControllerContext(BookstoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected Client GetClient()
        {
            return _context.Clients
                .SingleOrDefault(c => c.Id.ToString() == User.Identity.Name);
        }
    }
}
