using Task20_consumewebapioftask11_.Models;

namespace Task20_consumewebapioftask11_.ServiceLayer
{
    public interface ICustomerService
    {
        //IEnumerable<Customer> GetCustomerList();
        //public IEnumerable<Product> ProductList();
        Task<IEnumerable<Product>> ProductLists();
        Task<IEnumerable<Gender>> GenderLists();
        Task<List<CustomerList>> CustomerLists();
        Task<bool> Create(CustomerDto customer);
        Task<bool> Edit(int id,CustomerDto customer);
        Task<Customer> GetCustomerById(int productId);


        Task<bool> Delete(int id);



    }
}
