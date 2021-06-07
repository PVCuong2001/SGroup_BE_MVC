using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Test1.Extention;
using Test1.Model;

namespace Test1.Service
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> products;

        public ProductService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("MongoConnection"));
            IMongoDatabase database = client.GetDatabase("StoreManagement");
            products = database.GetCollection<Product>("Products");
        }


        public List<Product> Get(string keyWord, string orderBy)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Where(cus => true);
            ;
            SortDefinition<Product> sortDefinition = null;

            if (keyWord != "" && keyWord != null)
            {
                filter &= Builders<Product>.Filter.Where(x => x.Name.Contains(keyWord));
            }

            if (orderBy == "Name Asc")
            {
                sortDefinition = Builders<Product>.Sort.Ascending(x => x.Name);
            }

            if (orderBy == "Name Desc")
            {
                sortDefinition = Builders<Product>.Sort.Descending(x => x.Name);
            }

            if (orderBy == "Category")
            {
                sortDefinition = Builders<Product>.Sort.Ascending(x => x.Category);
            }

            return products.Find(filter).Sort(sortDefinition).ToList();
        }

        public Product FindById(string id)
        {
            return products.Find(x => x.Id == id).FirstOrDefault();
        }

        public Product Create(Product product)
        {
            product.SeoAlias = TextHelper.ToUnsignString(product.Name);
            products.InsertOne(product);
            return product;
        }

        public void Update(Product product)
        {
            product.SeoAlias = TextHelper.ToUnsignString(product.Name);
            products.ReplaceOne(cus => cus.Id == product.Id, product);
        }

        public void Remove(Product product)
        {
            products.DeleteOne(cus => cus.Id == product.Id);
        }

        public void Remove(string id)
        {
            products.DeleteOne(cus => cus.Id == id);
        }
    }
}