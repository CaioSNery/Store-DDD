using Store.Domain.Entities;
using Store.Domain.Queries;
using Xunit;

namespace Store.Tests.Queries

{
    
    public class ProductQueriesTests
    {

        private IList<Product> _products;
        public ProductQueriesTests()
        {
            _products = new List<Product>();
            _products.Add(new Product("Produto1", 10, true));
            _products.Add(new Product("Produto2", 20, true));
            _products.Add(new Product("Produto3", 30, true));
            _products.Add(new Product("Produto4", 40, false));
            _products.Add(new Product("Produto5", 50, false));

        }

        
       [Fact]
        public void DadoAConsultaDeProdutosAtivosDeveRetornar3()
        {
            var result = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());
            Assert.Equal(3, result.Count());

        }

        [Fact]
        [Trait("Queries", "Inactive Products")]
        public void DadoAConsultaDeProdutosInativosDeveRetornar2()
        {

            var result = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());
            Assert.Equal(2, result.Count());
        }


    }
}