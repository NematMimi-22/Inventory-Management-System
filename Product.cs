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
    }
}