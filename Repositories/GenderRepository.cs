using Task20_consumewebapioftask11_.Interfaces;
using Task20_consumewebapioftask11_.Models;
using Task20_consumewebapioftask11_.Repositories;

namespace Task20_consumewebapioftask11_.Repositories
{
    public class GenderRepository:GenericRepository<Gender>, IGenderRepository
    {
        public GenderRepository(ProductDbContext context) : base(context) { }
    }
}

