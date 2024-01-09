using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using Task20_consumewebapioftask11_.Interfaces;
using Task20_consumewebapioftask11_.Models;
using Task20_consumewebapioftask11_.Repositories;

namespace Task20_consumewebapioftask11_.ServiceLayer
{
    public class CustomerService:ICustomerService
    {
        private readonly ProductDbContext _dbcontext;
        //private readonly IProductService productService
        public readonly IUnitofworkRepository _unitofworkRepository;
        public CustomerService(IUnitofworkRepository unitofwork)
        {
            _unitofworkRepository = unitofwork;
        }
       
        //public async Task<IEnumerable<Gender>> ProductLists()
        //{
        //    return await _unitofworkRepository.Product.GetAllProducts();
        //}
        public async Task<List<CustomerList>> CustomerLists()
        {
            var customers = await _unitofworkRepository.Customer.GetAll();
            var products=await _unitofworkRepository.Product.GetAll();
            var genders=await _unitofworkRepository.Gender.GetAll();
            var res = (from Customer c in customers
                       join Product p in products on c.ProductId equals p.Id
                       join Gender g in genders on c.GenderId equals g.Id
                       select new CustomerList
                       {
                           Id=c.Id,
                           Name = c.Name,
                           Address = c.Address,
                           Email = c.Email,
                           Phone = c.Phone,
                           ProductName = p.ProductName,
                           GenderName = g.GenderName
                       }).ToList();

            return res;
            //var res = (from c in _dbcontext.Customer
            //           join p in _dbcontext.Product on c.ProductId equals p.Id
            //           join g in _dbcontext.Gender on c.GenderId equals g.Id
            //           select new
            //           {
            //               c.Id,
            //               c.Name,
            //               c.Address,
            //               c.Email,
            //               c.Phone,
            //               ProductName = p.ProductName,
            //               GenderName = g.GenderName
            //           }).AsEnumerable();

            //var customerList =  _unitofworkRepository.Customer.GetAll();
            //var result = from item1 in _unitOfWork.Table1.GetAll()
            //             join item2 in _unitOfWork.Table2.GetAll()
            //             on item1.CommonProperty equals item2.CommonProperty
            //             select new
            //             {
            //                 PropertyFromTable1 = item1.SomeProperty,
            //                 PropertyFromTable2 = item2.SomeProperty
            //             };

            //return customerList;

        }
        public async Task<IEnumerable<Product>> ProductLists()
        {
            var result= await _unitofworkRepository.Product.GetAll();
            return result;
        }
        public async Task<IEnumerable<Gender>> GenderLists()
        {
            var result=await _unitofworkRepository.Gender.GetAll();
            return result;  
        }


        public async Task<bool> Create(CustomerDto customerDto)
        {
            if(customerDto != null)
            {
                var customers = new Customer
                {
                    Name = customerDto.Name,
                    Address = customerDto.Address,
                    Phone = customerDto.Phone,
                    Email = customerDto.Email,
                    ProductId = customerDto.ProductId,
                    GenderId = customerDto.GenderId
                };
                await _unitofworkRepository.Customer.Add(customers);
                var result = _unitofworkRepository.Save();
                if (result > 0)
                {
                    return true;
                }
                else
                { return false; }
            }
            return false;
        }
        public async Task<Customer>GetCustomerById(int id)
        {
            if (id > 0)
            {
                var customer=await _unitofworkRepository.Customer.GetById(id);
                if(customer != null)
                {
                    return customer;
                }
            }
            return null;
        }
        public async Task<bool>Edit(int id,CustomerDto customerDto)
        {
            if (customerDto != null)
            {
                var existingCustomer = await _unitofworkRepository.Customer.GetById(id);
                if (existingCustomer != null)
                {
                    existingCustomer.Name = customerDto.Name;
                    existingCustomer.Address = customerDto.Address;
                    existingCustomer.Phone = customerDto.Phone;
                    existingCustomer.Email = customerDto.Email;
                    existingCustomer.ProductId = customerDto.ProductId;
                    existingCustomer.GenderId = customerDto.ProductId;
                    _unitofworkRepository.Customer.Update(existingCustomer);
                    var result = _unitofworkRepository.Save();
                    if(result>0) { return true; }
                    else { return false; }
                }

            }
            return false;
        }
        public async Task<bool> Delete(int id)
        {
            if (id > 0)
            {
                var customer = await _unitofworkRepository.Customer.GetById(id);
                if(customer != null)
                {
                    _unitofworkRepository.Customer.Delete(customer);
                    var result= _unitofworkRepository.Save();
                    if (result > 0)
                    {
                        return true;
                    }
                    else { return false; }
                }
            }
            return false;
        }
        
        






























        //public IEnumerable<Product> ProductList()
        //{
        //    return _dbcontext.Product.ToList();
        //}

        //public IEnumerable<Customer> CustomerLists()
        //{
           
        //        var res = (from c in _dbcontext.Customer
        //                   join p in _dbcontext.Product on c.ProductId equals p.Id
        //                   join g in _dbcontext.Gender on c.GenderId equals g.Id
        //                   select new
        //                   {
        //                       c.Id,
        //                       c.Name,
        //                       c.Address,
        //                       c.Email,
        //                       c.Phone,
        //                       ProductName = p.ProductName,
        //                       GenderName = g.GenderName
        //                   }).AsEnumerable();
        //    return (IEnumerable<Customer>)res;

        //}

        //static List<int> list = new List<int>();

        //public IEnumerable<Customer> GetCustomerList()
        //{
        //    var l=_dbcontext.Customer.ToList();
        //    GetProductList();
        //    for (int i = 0; i < l.Count; i++)
        //        {
        //        list.Add(l[i].ProductId);
        //        }




        //    return l;
        //}
        //public IEnumerable<Product> GetProductList() 
        //{
        //    IEnumerable<Product> pr=_dbcontext.Product.ToList();
        //    //for (int i = 0; i < list.Count; i++)
        //    //{
        //    //    //for (int j = 0; j < pr.Count; j++)
        //    //    //{
        //    //    //    if (list[i] == pr[j].Id)
        //    //    //    {
        //    //    //        //l[i].ProductName = pr[j].ProductName;
        //    //    //    }
        //    //    //}

        //    //}
        //    return pr;
        //}
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            try
            {
                var existingCustomer = await _dbcontext.Customer.FindAsync(id);
                if (existingCustomer == null)
                {
                    return false;
                }

                _dbcontext.Customer.Remove(existingCustomer);
                await _dbcontext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }




}
