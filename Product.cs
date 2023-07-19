using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Product
    {

        public Product()
        {
            
        }
        public string Name { get; set; }
        // "?" indicating that the price is not available or hasn't been set.
        public decimal ? price { get; set; }
        public int _quantity { get; set; }

    }
                    

}
