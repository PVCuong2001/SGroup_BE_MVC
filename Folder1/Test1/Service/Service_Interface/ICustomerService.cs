using System.Collections.Generic;
using Test1.Model;

namespace Test1.Service.Service_Interface
{
    public interface ICustomerService
    {
        public List<Customer> Get(string keyWord, string orderBy);
        public Customer FindById(string id);
        public Customer Create(Customer customer);
        public void Update(Customer customer);
        public void Remove(Customer customer);
        public void RemoveById(string id);
    }
}