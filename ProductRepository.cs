namespace IMS
{
    public class ProductRepository
    {
        public void AddProduct()
        {
            Console.WriteLine("Add a product: ");
            Console.Write("Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Product Price: ");
            decimal price;
            var isValidPrice = decimal.TryParse(Console.ReadLine(), out price);
            Console.Write("Product Quantity: ");
            int quantity;
            var isValidQuantity = int.TryParse(Console.ReadLine(), out quantity);
            if (isValidPrice && isValidQuantity)
            {
                Product product = new Product
                {
                    Name = name,
                    price = price,
                    quantity = quantity
                };
                Inventory.Products.Add(product);
                Console.WriteLine("Product is added.");
            }
            else
            {
                Console.WriteLine("Invalid input for price or quantity. Please enter a valid values");
            }
        }

        public static Product ValidProduct(string name)
        {

            return Inventory.Products.FirstOrDefault(p => p.Name == name);
        }

        public void DeleteProduct(string name)
        {
            var Product = ValidProduct(name);
            if (Product != null)
            {
                Inventory.Products.Remove(Product);
                Console.WriteLine($"'{name}'Product is deleted succesfully.");
            }
            else
            {
                Console.WriteLine($"Product with name '{name}' not found.");
            }
        }

        public void DisplayProducts()
        {
            foreach (Product product in Inventory.Products)
            {
                Console.WriteLine($"[ The product name: {product.Name}, The product price: {product.price}, The product quantity: {product.quantity}]");
            }
        }
        public void UpdateProduct(string name)
        {
            var product = Inventory.Products.FirstOrDefault(p => p.Name == name);
            if (product != null)
            {
                Console.WriteLine($"[ The product name: {product.Name}, The product price: {product.price}, The product quantity: {product.quantity}]");
                Console.WriteLine("Update the product: ");
                Console.Write("Product Name: ");
                string newName = Console.ReadLine();
                decimal price;
                Console.Write("Product Price: ");
                var isValidPrice = decimal.TryParse(Console.ReadLine(), out price);
                Console.Write("Product Quantity: ");
                int quantity;
                var isValidQuantity = int.TryParse(Console.ReadLine(), out quantity);
                if (isValidPrice && isValidQuantity)
                {
                    product.Name = newName;
                    product.price = price;
                    product.quantity = quantity;
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