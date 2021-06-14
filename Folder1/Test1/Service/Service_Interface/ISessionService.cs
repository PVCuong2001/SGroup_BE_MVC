using System.Collections.Generic;
using System.Threading.Tasks;
using Test1.Model;

namespace Test1.Service.Service_Interface
{
    public interface ISessionService
    {
        public Task<List<Session>> Get(Dictionary<string, string> properties);
        public Session CheckExistSession(string idUser);
        public  Task Create(Session session);
        public Task Update(Session session);
        
    }
}