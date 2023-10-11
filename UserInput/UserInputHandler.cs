public class UserInputHandler
{
    public string GetProductName()
    {
        Console.Write("Product Name: ");
        return Console.ReadLine();
    }

    public bool TryGetProductPrice(out decimal price)
    {
        Console.Write("Product Price: ");
        return decimal.TryParse(Console.ReadLine(), out price);
    }

    public bool TryGetProductQuantity(out int quantity)
    {
        Console.Write("Product Quantity: ");
        return int.TryParse(Console.ReadLine(), out quantity);
    }
}