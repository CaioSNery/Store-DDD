using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task SaveAsync(Order order);
        Task DeleteAsync(Order order);
        Task<Order> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetAllAsync(int skip = 0, int take = 25);
        Task<IEnumerable<Order>> GetWaitingPaymentOlderThanAsync(TimeSpan timeSpan);


    }
}