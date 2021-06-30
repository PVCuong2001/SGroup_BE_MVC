using System.Collections.Generic;
using System.Threading.Tasks;
using Test1.Model;

namespace Test1.Service.Service_Interface
{
    public interface IUserService
    {
        public Task<List<User>> findByProperty(Dictionary<string, string> properties);
        public bool checkLogin(string gmail, string password);
        public User findById(string id);
        public Task addUser(User user);
        public Task updateUser(User user);
    }
}