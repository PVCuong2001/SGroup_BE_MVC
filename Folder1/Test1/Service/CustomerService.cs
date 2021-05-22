using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Test1.Model;
using Test1.ViewModel;

namespace Test1.Service
{
    public class CustomerService
    {
         private readonly IMongoCollection<Customer> customers;

        public CustomerService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("CustomerManagement"));
            IMongoDatabase database = client.GetDatabase("CustomerManagement");
            customers = database.GetCollection<Customer>("Customers");
        }

        public List<Customer> Get(string keyWord , string orderBy)
        {
            FilterDefinition<Customer> filter =null;
            SortDefinition<Customer> sortDefinition = null;
            filter = Builders<Customer>.Filter.Where(cus => true);
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
        /*public Customer Get(string id)
        {
            return customers.Find(car => car.Id == id).FirstOrDefault();
        }*/

        public Customer Create(Customer car)
        {
            customers.InsertOne(car);
            return car;
        }

        public void Update(Customer customer)
        {
            customers.ReplaceOne(cus => cus.Id == customer.Id , customer);
        }

        public void Remove(Customer carIn)
        {
            customers.DeleteOne(car => car.Id == carIn.Id);
        }

        public void Remove(string id)
        {
            customers.DeleteOne(car => car.Id == id);
        }
    }
}