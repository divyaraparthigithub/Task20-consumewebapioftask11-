using Task20_consumewebapioftask11_.Interfaces;
using Task20_consumewebapioftask11_.Models;

namespace Task20_consumewebapioftask11_.Repositories
{
    public class UnitofWork:IUnitofworkRepository
    {
        private readonly ProductDbContext _context;
        public ICustomerRepository Customer { get; }
        public IProductRepository Product { get; }
        public IGenderRepository Gender { get; }
        //public ICustomerRepository CustomerDto { get; }
        public UnitofWork(ProductDbContext context,ICustomerRepository customerRepository,IProductRepository productRepository,IGenderRepository genderRepository)
        {
            _context = context;
            Customer = customerRepository;
            Product = productRepository;
            Gender = genderRepository;



        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
