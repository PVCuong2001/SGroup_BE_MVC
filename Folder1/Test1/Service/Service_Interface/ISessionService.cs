using System.Collections.Generic;
using Test1.Model;

namespace Test1.Service.Service_Interface
{
    public interface ISessionService
    {
        public List<Session> Get(Dictionary<string, string> properties);
        public Session CheckExistSession(string idUser);
        public Session Create(Session session);
        public void Update(Session session);
        
    }
}