using System.Collections.Generic;
using Test1.Model;
using Test1.ViewModel;

namespace Test1.Service.Service_Interface
{
    public interface IProductService
    {
        public List<ProductVM> Get(string keyWord, string orderBy);
        public Product FindById(string id);
        public Product Create(Product product);
        public void Update(Product product);
        public void Remove(Product product);
        public void RemoveById(string id);
    }
}