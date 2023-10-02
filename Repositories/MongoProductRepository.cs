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

        public void CreateProduct()
        {
            Console.WriteLine("Add a product: ");
            Console.Write("Product Name: ");
            var name = Console.ReadLine();
            Console.Write("Product Price: ");
            var isValidPrice = decimal.TryParse(Console.ReadLine(), out var price);
            Console.Write("Product Quantity: ");
            var isValidQuantity = int.TryParse(Console.ReadLine(), out var quantity);
            if (isValidPrice && isValidQuantity)
            {
                var product = new Product
                {
                    Name = name,
                    Price = price,
                    Quantity = quantity
                };
                _collection.InsertOne(product);
            }
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

        public void UpdateProduct(string oldProductName)
        {
            Console.WriteLine("Update the product: ");
            Console.Write("Product Name: ");
            var newName = Console.ReadLine();
            Console.Write("Product Price: ");
            var isValidPrice = decimal.TryParse(Console.ReadLine(), out var price);
            Console.Write("Product Quantity: ");
            var isValidQuantity = int.TryParse(Console.ReadLine(), out var quantity);

            if (isValidPrice && isValidQuantity)
            {
                var filter = Builders<Product>.Filter.Eq("PName", oldProductName);
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