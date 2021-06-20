using System.Collections.Generic;
using System.Threading.Tasks;
using Test1.Model;

namespace Test1.Service.Service_Interface
{
    public interface ICustomerService
    {
        public Task<List<Customer>> Get(string keyWord, string orderBy);
        public Task<Customer> FindById(string id);
        public Task Create(Customer customer);
        public  Task Update(Customer customer);
        public  Task Remove(Customer customer);
        public  Task RemoveById(string id);
    }
}