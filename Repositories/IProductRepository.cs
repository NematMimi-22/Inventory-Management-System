namespace IMS.Repositories
{
    public interface IProductRepository
    {
        void CreateProduct(Product newProduct);
        void DeleteProduct(string name);
        void DisplayProducts();
        Product GetValidProduct(string name);
        void UpdateProduct(Product product);
    }
}