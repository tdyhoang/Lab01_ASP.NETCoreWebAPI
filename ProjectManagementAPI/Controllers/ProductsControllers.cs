using BusinessObjects;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository repository = new ProductRepository();

    //GET: api/Products
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        return repository.GetProducts();
    }

    // POST: ProductsController/Products
    [HttpPost]
    public IActionResult PostProduct(Product p)
    {
        repository.SaveProduct(p);
        return NoContent();
    }

    // GET: ProductsController/Delete/5
    [HttpDelete("id")]
    public IActionResult DeleteProduct(int id)
    {
        var p = repository.GetProductById(id);
        if (p == null) return NotFound();
        repository.DeleteProduct(p);
        return NoContent();
    }

    [HttpPut("id")]
    public IActionResult UpdateProduct(int id, Product p)
    {
        var pTmp = repository.GetProductById(id);
        if (p == null) return NotFound();
        repository.UpdateProduct(p);
        return NoContent();
    }
}