﻿using Test;
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
            Console.WriteLine("You selected Option 1.");
    
            Console.ReadLine();

            break;

        case "2":
            Console.WriteLine("You selected Option 2.");
            Console.ReadLine();
            break;

        case "3":
            Console.WriteLine("You selected Option 2.");
            Console.ReadLine();
            break;

        case "5":
            Console.WriteLine("Please enter product name: ");
            string output = Console.ReadLine();
            Console.WriteLine("The product information: ");

            Console.WriteLine($"The Product Name: {Product.ValidProduct(output).Name}");
            Console.WriteLine($"The Product Price: {Product.ValidProduct(output).price}");
            Console.WriteLine($"The Product Quantity: {Product.ValidProduct(output).quantity}");

            Console.ReadLine();
            break;

        case "4":
            Console.WriteLine("You selected Option 2.");
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




