using System.Net.Http.Headers;
using System.Text.Json;
using BusinessObjects;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private readonly HttpClient client;
    private readonly string ProductApiUrl = "https://localhost:7069/api/products"; // Ensure the correct API URL

    public ProductController()
    {
        client = new HttpClient();
        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        client.DefaultRequestHeaders.Accept.Add(contentType);
    }

    // GET: ProductController
    public async Task<IActionResult> Index()
    {
        try
        {
            var response = await client.GetAsync(ProductApiUrl);
            response.EnsureSuccessStatusCode(); // Ensure request was successful

            var strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var listProducts = JsonSerializer.Deserialize<List<Product>>(strData, options);
            return View(listProducts);
        }
        catch (HttpRequestException ex)
        {
            // Log the exception and return an error view/message
            Console.WriteLine($"Request error: {ex.Message}");
            return View("Error", new ErrorViewModel { ErrorMessage = "Unable to retrieve product data." });
        }
    }

    // GET: ProductController/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ProductController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        try
        {
            var response = await client.PostAsJsonAsync(ProductApiUrl, product);
            response.EnsureSuccessStatusCode(); // Ensure request was successful

            return RedirectToAction(nameof(Index));
        }
        catch (HttpRequestException ex)
        {
            // Log the exception and return an error view/message
            Console.WriteLine($"Request error: {ex.Message}");
            return View("Error", new ErrorViewModel { ErrorMessage = "Unable to create product." });
        }
    }

    // Similar error handling can be added to other actions (Edit, Delete, etc.)
}