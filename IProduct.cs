namespace IMS
{
    public interface IProduct
    {
        string Name { get; set; }
        decimal? Price { get; set; }
        int Quantity { get; set; }
    }
}