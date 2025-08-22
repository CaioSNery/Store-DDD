using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class DeliveryFee : Entity
    {
        public DeliveryFee(string zipCode, decimal fee)
        {

            ZipCode = zipCode;
            Fee = fee;
        }


        public string ZipCode { get; set; }
        public decimal Fee { get; set; }
    }
}