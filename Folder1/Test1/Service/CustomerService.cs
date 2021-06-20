using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Test1.Extention;
using Test1.Model;
using Test1.Service.Service_Interface;
using Test1.ViewModel;

namespace Test1.Service
{
    public class CustomerService : ICustomerService
    {
         private readonly IMongoCollection<Customer> customers;

        public CustomerService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("MongoConnection"));
            IMongoDatabase database = client.GetDatabase("StoreManagement");
            customers = database.GetCollection<Customer>("Customers");
        }

        public async Task<List<Customer>> Get(string keyWord , string orderBy)
        {
            FilterDefinition<Customer> filter =Builders<Customer>.Filter.Where(cus => true);;
            SortDefinition<Customer> sortDefinition = null;
           
            if(keyWord !="" && keyWord !=null) {
                filter &= Builders<Customer>.Filter.Where(x => x.Name.Contains(keyWord));
                return customers.Find(filter).ToList();
            }
            if (orderBy == "Name Asc")
            {
                sortDefinition = Builders<Customer>.Sort.Ascending(x => x.Name);
            }
            if (orderBy == "Name Desc")
            {
                sortDefinition = Builders<Customer>.Sort.Descending(x => x.Name);
            }
            if (orderBy == "Gender")
            {
                sortDefinition = Builders<Customer>.Sort.Ascending(x => x.Gender);
            }
            return await customers.Find(filter).Sort(sortDefinition).ToListAsync();
        }
        public async Task<Customer> FindById(string id)
        {
            return await customers.Find(x =>x.Id ==id).SingleOrDefaultAsync();
        }

        public async Task Create(Customer customer)
        {
            customer.SeoAlias = TextHelper.ToUnsignString(customer.Name);
            await  customers.InsertOneAsync(customer);
        }

        public async Task Update(Customer customer)
        {
            customer.SeoAlias = TextHelper.ToUnsignString(customer.Name);
            await customers.ReplaceOneAsync(cus => cus.Id == customer.Id , customer);
        }

        public async Task  Remove(Customer customer)
        {
            await customers.DeleteOneAsync(cus => cus.Id == customer.Id);
        }

        public async Task  RemoveById(string id)
        {
            await customers.DeleteOneAsync(cus => cus.Id == id);
        }
    }
}