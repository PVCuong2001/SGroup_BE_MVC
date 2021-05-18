using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Test1.Model;

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

        public List<Customer> Get()
        {
            return customers.Find(car => true).ToList();
        }
        public Customer Get(string id)
        {
            return customers.Find(car => car.Id == id).FirstOrDefault();
        }

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