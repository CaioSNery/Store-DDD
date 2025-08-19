

using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Get(IEnumerable<Guid> ids)
        {
            IList<Product> products = new List<Product>();
            products.Add(new Product("Produto1", 10, true));
            products.Add(new Product("Produto2", 10, true));
            products.Add(new Product("Produto3", 10, true));
            products.Add(new Product("Produto4", 10, true));
            products.Add(new Product("Produto5", 10, true));
            products.Add(new Product("Produto6", 10, true));

            return products;
        }
    }
}