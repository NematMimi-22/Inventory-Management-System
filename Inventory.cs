using IMS;
using IMS.Repositories;
public class Inventory
{
    private readonly IProductRepository _productRepository;
    public Inventory(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }
    public static void Main()
    {
        IProductRepository productRepository;
        Inventory inventory;
        Console.WriteLine("Choose a repository type:");
        Console.WriteLine("1. No Database");
        Console.WriteLine("2. MSSQL Database");
        Console.WriteLine("3. Monogo Database");
        Console.Write("Enter your choice: ");
        var repoChoice = Console.ReadLine();

        switch (repoChoice)
        {
            case "1":
                productRepository = new ProductRepository();
                inventory = new Inventory(productRepository);
                break;
            case "2":
                productRepository = new MSSQLProductRepository();
                inventory = new Inventory(productRepository);
                break;
            case "3":
                productRepository = new MongoDBProductRepository();
                inventory = new Inventory(productRepository);
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting...");
                return;
        }
        bool exit = false;
        exit = MainMenu(exit, inventory);
    }

    private static bool MainMenu(bool exit, Inventory inventory)
    {
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
                    inventory._productRepository.CreateProduct();
                    Console.ReadLine();
                    break;

                case "2":
                    Console.WriteLine("The List of all Products:");
                    inventory._productRepository.DisplayProducts();
                    Console.ReadLine();
                    break;

                case "3":
                    Console.WriteLine("Please enter product name: ");
                    var ProductNameToUpdate = Console.ReadLine();
                    inventory._productRepository.UpdateProduct(ProductNameToUpdate);
                    Console.ReadLine();
                    break;

                case "5":
                    Console.WriteLine("Please enter product name: ");
                    var ProductName = Console.ReadLine();
                    var product = inventory._productRepository.GetValidProduct(ProductName);
                    Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
                    Console.ReadLine();
                    break;

                case "4":
                    Console.WriteLine("Please enter the name of product you want to delete: ");
                    var DeletedProductName = Console.ReadLine();
                    inventory._productRepository.DeleteProduct(DeletedProductName);
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

        return exit;
    }
}