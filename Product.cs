using MongoDB.Bson.Serialization.Attributes;

namespace IMS
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonElement("PName")]
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
    }
}