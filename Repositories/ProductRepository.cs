namespace IMS.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> Products = new List<Product>();

        public void CreateProduct(Product product)
        {
                Products.Add(product);
                Console.WriteLine("Product is added.");
        }

        public Product GetValidProduct(string name)
        {
            return Products.FirstOrDefault(p => p.Name == name);
        }

        public void DeleteProduct(string name)
        {
            var Product = GetValidProduct(name);
            if (Product != null)
            {
                Products.Remove(Product);
                Console.WriteLine($"'{name}'Product is deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Product with name '{name}' not found.");
            }
        }

        public void DisplayProducts()
        {
            foreach (var product in Products)
            {
                Console.WriteLine($"[ The product name: {product.Name}, The product price: {product.Price}, The product quantity: {product.Quantity}]");
            }
        }

        public void UpdateProduct(Product product)
        {
            if (product != null)
            {
                Console.WriteLine($"[ The product name: {product.Name}, The product price: {product.Price}, The product quantity: {product.Quantity}]");
                Console.WriteLine("Update the product: ");
                var userInputHandler = new UserInputHandler();
                var newName = userInputHandler.GetProductName();
                var isValidPrice = userInputHandler.TryGetProductPrice(out var price);
                var isValidQuantity = userInputHandler.TryGetProductQuantity(out var quantity);
                if (isValidPrice && isValidQuantity)
                {
                    product.Name = newName;
                    product.Price = price;
                    product.Quantity = quantity;
                    Console.WriteLine($"'{product.Name}'Product is updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid input for price or quantity. Please enter a valid values");
                }
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }
}