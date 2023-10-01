namespace IMS.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> Products = new List<Product>();

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
                Product product = new Product
                {
                    Name = name,
                    Price = price,
                    Quantity = quantity
                };
                Products.Add(product);
                Console.WriteLine("Product is added.");
            }
            else
            {
                Console.WriteLine("Invalid input for price or quantity. Please enter a valid values");
            }
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
        public void UpdateProduct(string name)
        {
            var product = Products.FirstOrDefault(p => p.Name == name);
            if (product != null)
            {
                Console.WriteLine($"[ The product name: {product.Name}, The product price: {product.Price}, The product quantity: {product.Quantity}]");
                Console.WriteLine("Update the product: ");
                Console.Write("Product Name: ");
                var newName = Console.ReadLine();
                Console.Write("Product Price: ");
                var isValidPrice = decimal.TryParse(Console.ReadLine(), out var price);
                Console.Write("Product Quantity: ");
                var isValidQuantity = int.TryParse(Console.ReadLine(), out var quantity);
                if (isValidPrice && isValidQuantity)
                {
                    product.Name = newName;
                    product.Price = price;
                    product.Quantity = quantity;
                    Console.WriteLine($"'{name}'Product is updated successfully.");
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