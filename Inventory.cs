using System;
using System.Xml.Linq;
using Test;
 static Product ValidProduct(string name)
{
    // Find the first product object in the list whose name matches the given name
    Product product = Product.products.FirstOrDefault(p => p.Name == name);

    return product;


}


 static void DeleteProduct(string name)
{
    // Find the first product object in the list whose name matches the given name
    Product product = Product.products.FirstOrDefault(p => p.Name == name);
    if (product != null)
    {
        Product.products.Remove(product);

        Console.WriteLine($"'{name}'Product is deleted succesfully.");

    }
    else
    {

        Console.WriteLine($"Product with name '{name}' not found.");

    }

}



 static void UpdateProduct(string name)
{
    Product product = Product.products.FirstOrDefault(p => p.Name == name);

    if (product != null)
    {
        Console.WriteLine($"[ The product name: {product.Name}, The product price: {product.price}, The product quantity: {product.quantity}]");

        Console.WriteLine("Update the product: ");
        Console.Write("Product Name: ");
        string newName = Console.ReadLine();
        decimal price;
        Console.Write("Product Price: ");

        bool isValidPrice = decimal.TryParse(Console.ReadLine(), out price);
        Console.Write("Product Quantity: ");
        int quantity;
        bool isValidQuantity = int.TryParse(Console.ReadLine(), out quantity);
        if (isValidPrice && isValidQuantity)
        {

            product.Name = newName;
            product.price = price;
            product.quantity = quantity;
            Console.WriteLine($"'{name}'Product is updated succesfully.");

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


static void AddProduct()
{

    Console.WriteLine("Add a product: ");
    Console.Write("Product Name: ");
    string name = Console.ReadLine();
    Console.Write("Product Price: ");
    decimal price;

    bool isValidPrice = decimal.TryParse(Console.ReadLine(), out price);
    Console.Write("Product Quantity: ");
    int quantity;
    bool isValidQuantity = int.TryParse(Console.ReadLine(), out quantity);
    if (isValidPrice && isValidQuantity)
    {

        Product product = new Product
        {
            Name = name,
            price = price,
            quantity = quantity

        };

        Product.products.Add(product);

        Console.WriteLine("Product is added.");
    }
    else
    {
        Console.WriteLine("Invalid input for price or quantity. Please enter a valid values");
    }
}


 static void DisplayProducts()
{

    foreach (Product product in Product.products)
    {

        Console.WriteLine($"[ The product name: {product.Name}, The product price: {product.price}, The product quantity: {product.quantity}]");
    }

}







bool exit = false;

while (!exit)
{
   
    Console.Clear();
    Console.WriteLine("Main Menu");
    Console.WriteLine("1.Add a product");
    Console.WriteLine("2.View all products");
    Console.WriteLine("3.Edit a product");
    Console.WriteLine("4.Delete a product");
    Console.WriteLine("5.Search for a product");
    Console.WriteLine("6. Exit");
    Console.WriteLine();
    Console.Write("Enter your choice: ");
    string input = Console.ReadLine();
    switch (input)
    {
        case "1":
            AddProduct();
            Console.ReadLine();

            break;

        case "2":
            Console.WriteLine("The List of all Products:");
           DisplayProducts();
            Console.ReadLine();
            break;

        case "3":
            Console.WriteLine("Please enter product name: ");
            string ProductNameToUpdate = Console.ReadLine();
            UpdateProduct(ProductNameToUpdate);
            Console.ReadLine();
            break;

        case "5":
            Console.WriteLine("Please enter product name: ");
            string ProductName = Console.ReadLine();
            Product pro=ValidProduct(ProductName);
            if (pro != null)
            {
                Console.WriteLine("The product information: ");

                Console.WriteLine($"The Product Name: {pro.Name}");
                Console.WriteLine($"The Product Price: {pro.price}");
                Console.WriteLine($"The Product Quantity: {pro.quantity}");
               
            }
            else
            {
                Console.WriteLine($"Product {ProductName} not found.");
            }

            Console.ReadLine();
            break;

        case "4":
            Console.WriteLine("Please enter the name of product you want to delete: ");
            string DeletedProductName = Console.ReadLine();
           DeleteProduct(DeletedProductName);
            Console.ReadLine();
            break;
        case "6":
            exit = true;
            break;

        default:
            Console.WriteLine("Invalid input. Press enter to try again.");
            Console.ReadLine();
            break;
    }
}




