

using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories
{
    public class FakeOrderRepository : IOrderRepository
    {
        public Task DeleteAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllAsync(int skip = 0, int take = 25)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetWaitingPaymentOlderThanAsync(TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Order order)
        {
            return Task.CompletedTask;
        }
    }
}