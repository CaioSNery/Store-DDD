using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Application.Commands;
using Store.Application.Handlers;


namespace Store.Application.Utils
{
    public static class ExtractGuids
    {
        public static IEnumerable<Guid> Extract(IList<CreateOrderItemCommand> items)
        {
            var guids = new List<Guid>();
            foreach (var item in items)
            {
                guids.Add(item.Product);
            }

            return guids;
        }
    }
}