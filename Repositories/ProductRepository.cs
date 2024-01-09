using Task20_consumewebapioftask11_.Interfaces;
using Task20_consumewebapioftask11_.Models;

namespace Task20_consumewebapioftask11_.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context) { }
    }
}
