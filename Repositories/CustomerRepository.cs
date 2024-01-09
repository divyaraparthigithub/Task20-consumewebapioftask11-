using Task20_consumewebapioftask11_.Interfaces;
using Task20_consumewebapioftask11_.Models;

namespace Task20_consumewebapioftask11_.Repositories
{
    public class CustomerRepository:GenericRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(ProductDbContext context) : base(context) { }
    }
}
