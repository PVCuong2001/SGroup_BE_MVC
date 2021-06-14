using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Test1.Extention;
using Test1.Model;
using Test1.Service.Service_Interface;
using Test1.ViewModel;

namespace Test1.Service
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> products;
        private readonly IMapper _mapper;

        public ProductService(IConfiguration config ,IMapper mapper)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("MongoConnection"));
            IMongoDatabase database = client.GetDatabase("StoreManagement");
            products = database.GetCollection<Product>("Products");
            _mapper = mapper;
        }


        public List<ProductVM> Get(string keyWord, string orderBy)
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
            List<Product> list = products.Find(filter).Sort(sortDefinition).ToList();
            List<ProductVM> listVM = new List<ProductVM>();
            foreach (var product in list)
            {
                ProductVM productVm = _mapper.Map<ProductVM>(product);
                listVM.Add(productVm);
            }

            return listVM;
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

        public void RemoveById(string id)
        {
            products.DeleteOne(cus => cus.Id == id);
        }
    }
}