using MongoDB.Bson;
using MongoDB.Driver;
namespace IMS.Repositories
{
    public class MongoDBProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _collection;
        private string connectionString = "mongodb://localhost:27017";

        public MongoDBProductRepository()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("IMS");
            _collection = database.GetCollection<Product>("IMS");
        }

        public Product GetValidProduct(string productName)
        {
            var filter = Builders<Product>.Filter.Eq("PName", productName);
            return _collection.Find(filter).FirstOrDefault();
        }

        public void CreateProduct(Product product)
        {
            _collection.InsertOne(product);           
        }

        public void DisplayProducts()
        {
            var products = _collection.Find(new BsonDocument()).ToList();
            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
                Console.WriteLine("------------");
            }
        }

        public void UpdateProduct(Product product)
        {
            Console.WriteLine("Update the product: ");
            var userInputHandler = new UserInputHandler();
            var newName = userInputHandler.GetProductName();
            var isValidPrice = userInputHandler.TryGetProductPrice(out var price);
            var isValidQuantity = userInputHandler.TryGetProductQuantity(out var quantity);
            if (isValidPrice && isValidQuantity)
            {
                var filter = Builders<Product>.Filter.Eq("PName", product.Name);
                var update = Builders<Product>.Update
                    .Set("PName", newName)
                    .Set("Price", price)
                    .Set("Quantity", quantity);

                _collection.UpdateOne(filter, update);
            }
        }

        public void DeleteProduct(string productName)
        {
            var filter = Builders<Product>.Filter.Eq("PName", productName);
            _collection.DeleteOne(filter);
        }
    }
}