using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Types
{
    public enum OrderType
    {
        PaymentSuccessful = 0,
        PaymentVerified = 1,
        Processing = 2,
        Shipped = 3,
        Completed = 4
    }
}   