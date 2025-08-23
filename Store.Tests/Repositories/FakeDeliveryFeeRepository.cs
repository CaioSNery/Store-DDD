
using Store.Domain.Repositories;


namespace Store.Tests.Repositories
{
    public class FakeDeliveryFeeRepository : IDeliveryFeeRepository
    {
        public decimal Get(string code)
        {
            return 10;
        }

        Task<decimal> IDeliveryFeeRepository.Get(string zipCode)
        {
            throw new NotImplementedException();
        }
    }
}