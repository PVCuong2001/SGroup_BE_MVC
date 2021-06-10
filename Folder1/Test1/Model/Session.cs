using System;
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
        
        [BsonElement("Cookie")]
        [Required]
        public string Cookie { get; set; }
        
        [BsonElement("LoginTime")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LoginTime { get; set; }
        
        [BsonElement("ExpiredTime")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExpiredTime { get; set; }
        
        [BsonElement("LastAccessTime")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LastAccessTime { get; set; }
        
        [BsonElement("ActiveFlag")]
        [Required]
        public bool ActiveFlag { get; set; }
    }
}