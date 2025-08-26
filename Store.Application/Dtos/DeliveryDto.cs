using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Application.Dtos
{
    public class DeliveryDto
    {
        public Guid OrderId { get; set; }
        
        public bool Payment { get; set; }
    }
}