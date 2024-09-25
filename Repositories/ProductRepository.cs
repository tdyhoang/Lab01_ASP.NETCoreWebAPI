using BusinessObjects;

public class ProductRepository : IProductRepository
{
    public void DeleteProduct(Product p)
    {
        ProductDAO.DeleteProduct(p);
    }

    public void SaveProduct(Product p)
    {
        ProductDAO.SaveProduct(p);
    }

    public void UpdateProduct(Product p)
    {
        ProductDAO.UpdateProduct(p);
    }

    public List<Category> GetCategories()
    {
        return CategoryDAO.GetCategories();
    }

    public List<Product> GetProducts()
    {
        return ProductDAO.GetProducts();
    }

    public Product GetProductById(int id)
    {
        return ProductDAO.FindProductById(id);
    }
}