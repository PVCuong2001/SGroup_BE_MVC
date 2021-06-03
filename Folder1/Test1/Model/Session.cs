using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Test1.Model
{
    public class Session
    {
        
         [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        
        [BsonElement("UserId")]
        [Required]
        public string UserId { get; set; }
        
        [BsonElement("Token")]
        [Required]
        public string Token { get; set; }
        
        [BsonElement("ActiveFlag")]
        [Required]
        public string ActiveFlag { get; set; }
    }
}