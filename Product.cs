using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Product
    {
        public static List<Product> products = new List<Product>
        {
            new Product {Name="pro1",price=22,quantity=44},
            new Product {Name="pro2",price=24,quantity=44}

        };

        public Product()
        {

        }
        public string Name { get; set; }
        public decimal? price { get; set; }
        public int quantity { get; set; }

        public static Product ValidProduct(string name)
        {
            // Find the first product object in the list whose name matches the given name
            Product product = products.FirstOrDefault(p => p.Name == name);
            if (product!= null)
            {
                return product;
            }
            else
            {

                Console.WriteLine($"Product with name '{name}' not found.");
                return product;
            }

        }

        public static void AddProduct()
        {

            Console.WriteLine("Add a product: ");
            Console.Write("Product Name: ");
            string name = Console.ReadLine();



            Console.Write("Product Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Product Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Product product = new Product
            {
                Name = name,
                price = price,
                quantity = quantity

            };

            Product.products.Add(product);

            Console.WriteLine("Product is added.");



        }


        public static void DisplayProducts()
        {

        foreach (Product product in products)
            {

                   Console.WriteLine($"The product name: {product.Name}, The product price: {product.price}, The product quantity: {product.quantity}");
            }



        }







    }
}