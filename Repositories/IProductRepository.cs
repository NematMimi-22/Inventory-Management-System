namespace IMS.Repositories
{
    public interface IProductRepository
    {
        void CreateProduct();
        void DeleteProduct(string name);
        void DisplayProducts();
        Product GetValidProduct(string name);
        void UpdateProduct(string name);
    }
}