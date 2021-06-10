
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Test1.Model;

namespace Test1.Service
{
    public class SessionService
    {
        private readonly IMongoCollection<Session> sessions;

        public SessionService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("MongoConnection"));
            IMongoDatabase database = client.GetDatabase("StoreManagement");
            sessions = database.GetCollection<Session>("Sessions");
        }
        
        public List<Session> Get(Dictionary<string , string > properties)
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
            
            return sessions.Find(filter).ToList();
        }

        public Session CheckExistSession(string idUser)
        {
            FilterDefinition<Session> filter =Builders<Session>.Filter.Where(x => true);;
            filter &= Builders<Session>.Filter.Where(x => x.Id.Equals(idUser));
            filter &= Builders<Session>.Filter.Where(x => x.ActiveFlag == true);
            filter &= Builders<Session>.Filter.Where(x => x.ExpiredTime > DateTime.Now);
            return sessions.Find(filter).FirstOrDefault();
        }
        
        public Session Create(Session session)
        {
            sessions.InsertOne(session);
            return session;
        }
        
        public void Update(Session session)
        {
            sessions.ReplaceOne(x => x.Id == session.Id , session);
        }
    }
}