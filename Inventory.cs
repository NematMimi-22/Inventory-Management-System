﻿using IMS;
public class Inventory : IInventory
{
    public List<Product> Products { get; } = new List<Product>();
    public static void Main()
    {
        IInventory inventory = new Inventory();
        ProductRepository productRepository = new ProductRepository(inventory);
        var exit = false;

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
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    productRepository.AddProduct();
                    Console.ReadLine();
                    break;

                case "2":
                    Console.WriteLine("The List of all Products:");
                    productRepository.DisplayProducts();
                    Console.ReadLine();
                    break;

                case "3":
                    Console.WriteLine("Please enter product name: ");
                    var ProductNameToUpdate = Console.ReadLine();
                    productRepository.UpdateProduct(ProductNameToUpdate);
                    Console.ReadLine();
                    break;

                case "5":
                    Console.WriteLine("Please enter product name: ");
                    string ProductName = Console.ReadLine();
                    var product = productRepository.ValidProduct(ProductName);
                    if (product != null)
                    {
                        Console.WriteLine("The product information: ");
                        Console.WriteLine($"The Product Name: {product.Name}");
                        Console.WriteLine($"The Product Price: {product.price}");
                        Console.WriteLine($"The Product Quantity: {product.quantity}");
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
                    productRepository.DeleteProduct(DeletedProductName);
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
}
}