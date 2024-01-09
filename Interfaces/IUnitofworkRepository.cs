using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task20_consumewebapioftask11_.Interfaces
{
    public interface IUnitofworkRepository:IDisposable
    {
       public  ICustomerRepository Customer { get; }
       public IProductRepository Product { get; }
       public IGenderRepository Gender { get; }
        //void IDisposable.Dispose()
        //{
        //    throw new NotImplementedException();
        //}


        int Save();
    }
}
