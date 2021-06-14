
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Test1.Model;
using Test1.Service.Service_Interface;

namespace Test1.Service
{
    public class SessionService : ISessionService
    {
        private readonly IMongoCollection<Session> sessions;

        public SessionService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("MongoConnection"));
            IMongoDatabase database = client.GetDatabase("StoreManagement");
            sessions = database.GetCollection<Session>("Sessions");
        }
        
        public async Task<List<Session>> Get(Dictionary<string , string > properties)
        {
            FilterDefinition<Session> filter =Builders<Session>.Filter.Where(x => true);;
            if(properties.ContainsKey("idUser")) {
                filter &= Builders<Session>.Filter.Where(x => x.UserId.Equals(properties["idUser"]));
            }
            if(properties.ContainsKey("cookie")) {
                filter &= Builders<Session>.Filter.Where(x => x.Cookie.Equals(properties["cookie"]));
            }
            if(properties.ContainsKey("status")) {
                if(properties["status"] == "Active") filter &= Builders<Session>.Filter.Where(x => x.ActiveFlag == true );
                else if(properties["status"] == "Inactive") filter &= Builders<Session>.Filter.Where(x => x.ActiveFlag == false );
            }

            var query =await sessions.FindAsync(filter);
            var list = query.ToList();
            return list;
        }

        public Session CheckExistSession(string idUser)
        {
            FilterDefinition<Session> filter =Builders<Session>.Filter.Where(x => true);;
            filter &= Builders<Session>.Filter.Where(x => x.Id.Equals(idUser));
            filter &= Builders<Session>.Filter.Where(x => x.ActiveFlag == true);
            filter &= Builders<Session>.Filter.Where(x => x.ExpiredTime > DateTime.Now);
            return sessions.Find(filter).FirstOrDefault();
        }
        
        public async Task Create(Session session)
        {
            await sessions.InsertOneAsync(session);
        }
        
        public async Task Update(Session session)
        {
            await sessions.ReplaceOneAsync(x => x.Id == session.Id , session);
        }
    }
}