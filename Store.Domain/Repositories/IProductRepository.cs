using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAsync(IEnumerable<Guid> ids);

        Task<IEnumerable<Product>> GetAllAsync(int skip = 0, int take = 25);

        Task SaveAsync(Product product);

        Task DeleteAsync(Product product);

        Task UpdateAsync(Product product);

        Task<Product> GetByIdAsync(Guid id);

    }
}