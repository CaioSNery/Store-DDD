using Store.Domain.Entities;
using Store.Domain.Repositories;


namespace Store.Tests.Repositories
{
    public class FakeCostumerRepository : ICustomerRepository
    {
        public Customer Get(string document)
        {
            if (document == "12345678911")
                return new Customer("Caio Nery", "caio@caio.com");
            return null;
        }
    }
}