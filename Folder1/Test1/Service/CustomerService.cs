using System.Collections.Generic;
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

        public List<Customer> Get(string keyWord , string orderBy)
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
        
            return customers.Find(filter).Sort(sortDefinition).ToList();
        }
        public Customer FindById(string id)
        {
            return customers.Find(x => x.Id == id).FirstOrDefault();
        }

        public Customer Create(Customer customer)
        {
            customer.SeoAlias = TextHelper.ToUnsignString(customer.Name);
            customers.InsertOne(customer);
            return customer;
        }

        public void Update(Customer customer)
        {
            customer.SeoAlias = TextHelper.ToUnsignString(customer.Name);
            customers.ReplaceOne(cus => cus.Id == customer.Id , customer);
        }

        public void Remove(Customer customer)
        {
            customers.DeleteOne(cus => cus.Id == customer.Id);
        }

        public void RemoveById(string id)
        {
            customers.DeleteOne(cus => cus.Id == id);
        }
    }
}