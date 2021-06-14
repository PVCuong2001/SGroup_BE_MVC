using System.Collections.Generic;
using Test1.Model;

namespace Test1.Service.Service_Interface
{
    public interface IUserService
    {
        public List<User> findByProperty(Dictionary<string, string> properties);
        public bool checkLogin(string gmail, string password);
        public User findById(string id);
        public void addUser(User user);
        public void updateUser(User user);
    }
}