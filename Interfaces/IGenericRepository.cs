using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task20_consumewebapioftask11_.Interfaces
{
    public interface IGenericRepository<T> where T : class 
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllProducts();
        Task<IEnumerable<T>> GetAllGenders();
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
