using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Test1.Model
{
    public class Image
    {
        [BsonElement("Public_Id")]
        [Required]
        public string PublicId { get; set; }
        
        [BsonElement("ImageUrl")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrl { get; set; }
    }
}