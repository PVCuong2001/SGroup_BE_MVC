using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Test1.Model
{
    public class Product
    {
         [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [Required]
        public string Name { get; set; }
        
        [BsonElement("SeoAlias")]
        [Required]
        public string SeoAlias { get; set; }

        [BsonElement("Branch")]
        [Required]
        public string Branch { get; set; }

        [BsonElement("Category")]
        [Required]
        public string Category { get; set; }
        
        [BsonElement("ImageUrl")]
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrl { get; set; }
    }
}