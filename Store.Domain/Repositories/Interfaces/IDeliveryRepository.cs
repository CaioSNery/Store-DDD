using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Entities;

namespace Store.Domain.Repositories.Interfaces
{
    public interface IDeliveryRepository
    {
        Task SaveAsync(Delivery delivery);
        Task<Delivery> GetByIdAsync(Guid id);
        Task<IEnumerable<Delivery>> GetAllAsync(int skip = 0, int take = 25);
    }
}