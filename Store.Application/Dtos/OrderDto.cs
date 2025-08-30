using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Application.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string CustomerName { get; set; }
        public Guid CustomerId { get; set; }

    }


}