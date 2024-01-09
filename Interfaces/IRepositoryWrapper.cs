namespace Task20_consumewebapioftask11_.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        IProductRepository Product { get; }
        IGenderRepository Gender { get; }
    }
}
