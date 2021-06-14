using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Test1.Extention;
using Test1.Model;
using Test1.Service.Service_Interface;
using Test1.ViewModel;

namespace Test1.Service
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> users;

        public UserService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("MongoConnection"));
            IMongoDatabase database = client.GetDatabase("StoreManagement");
            users = database.GetCollection<User>("Users");
        }

        public List<User> findByProperty(Dictionary<string, string> properties)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Where(cus => true);
            if (properties.ContainsKey("Gmail"))
                filter &= Builders<User>.Filter.Where(x => x.Gmail.Equals(properties["Gmail"]));
            if (properties.ContainsKey("Password"))
            {
                string Md5pass = Md5.CreateMD5Hash(properties["Password"]);
                filter &= Builders<User>.Filter.Where(x => x.Password.Equals(Md5pass));
            }

            return users.Find(filter).ToList();
        }

        public bool checkLogin(string gmail, string password)
        {
            User user = users.Find(x => x.Gmail.Equals(gmail) && x.Password.Equals(password)).SingleOrDefault();
            if (user != null) return true;
            return false;
        }

        public User findById(string id)
        {
            return users.Find(x => x.Id == id).SingleOrDefault();
        }

        public void addUser(User user)
        {
            user.Password = Md5.CreateMD5Hash(user.Password);
            users.InsertOne(user);
        }

        public void updateUser(User user)
        {
            user.Password = Md5.CreateMD5Hash(user.Password);
            users.ReplaceOne(x => x.Id == user.Id, user);
        }
    }
}