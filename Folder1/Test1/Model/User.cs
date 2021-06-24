using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Test1.Model
{
    public class User
    {
         [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [Required]
        public string Name { get; set; }
        
        [BsonElement("Password")]
        [Required]
        public string Password { get; set; }

        [BsonElement("Gmail")]
        [Required]
        public string Gmail { get; set; }
        
        [BsonElement("ImageUrl")]
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrl { get; set; }
        
        [BsonElement("AboutYourSelf")]
        [Required]
        [DataType(DataType.Url)]
        public string AboutYourSelf { get; set; }
        
    }
}