using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization; 
using siddhi_store_backend.Models;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{

    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _productRepository.GetAllProducts();
        // Return empty list if null to avoid 404
    if (products == null)
    {
        products = new List<Product>();
    }
        return Ok(products);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var product = _productRepository.GetProductById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

// Add a new product
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult AddProduct(Product product)
    {
        _productRepository.AddProduct(product);
        _productRepository.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

// Update a product
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateProduct(Guid id, Product product)
    {
        if (id != product.Id) return BadRequest();

        _productRepository.UpdateProduct(product);
        _productRepository.SaveChanges();
        return NoContent();
    }

// Delete a product
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteProduct(Guid id)
    {
        _productRepository.DeleteProduct(id);
        _productRepository.SaveChanges();
        return NoContent(); 
    }


}
