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

                Console.WriteLine($"Person with name '{name}' not found.");
                return null;
            }


        }








    }
}