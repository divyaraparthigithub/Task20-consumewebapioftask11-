using Task20_consumewebapioftask11_.Interfaces;
using Task20_consumewebapioftask11_.Models;

namespace Task20_consumewebapioftask11_.Repositories
{
    public class RepositoryWrapper:IRepositoryWrapper
    {
        private ProductDbContext _productDbContext;
        private IProductRepository _productRepository;
        private IGenderRepository _genderRepository;
        private ICustomerRepository _customerRepository;
        public IProductRepository Product
        {
            get
            {
                if(_productRepository == null) 
                {
                    _productRepository = new ProductRepository(_productDbContext);
                }
                return _productRepository;
            }
           
        }
        public IGenderRepository Gender
        {
            get
            {
                if (_genderRepository == null)
                {
                    _genderRepository = new GenderRepository(_productDbContext);
                }
                return _genderRepository;
            }

        }
        public ICustomerRepository Customer
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository=new CustomerRepository(_productDbContext);
                }
                return _customerRepository;
            }
        }

    }
}
