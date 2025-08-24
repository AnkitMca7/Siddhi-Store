using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using siddhi_store_backend.Models;
using System;

[ApiController]
[Route("api/[controller]")]
public class ProductItemsController : ControllerBase
{
    private readonly IProductItemRepository _productItemRepository;

    public ProductItemsController(IProductItemRepository productItemRepository)
    {
        _productItemRepository = productItemRepository;
    }

    // GET: api/productitems
    [HttpGet]
    public IActionResult GetAll()
    {
        var productItems = _productItemRepository.GetAllProductItems();
        return Ok(productItems);
    }

    // GET: api/productitems/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var productItem = _productItemRepository.GetProductItemById(id);
        if (productItem == null)
            return NotFound();
        return Ok(productItem);
    }

    // POST: api/productitems
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult AddProductItem(ProductItem productItem)
    {
        _productItemRepository.AddProductItem(productItem);
        _productItemRepository.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = productItem.Id }, productItem);
    }

    // PUT: api/productitems/{id}
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateProductItem(Guid id, ProductItem productItem)
    {
        if (id != productItem.Id)
            return BadRequest();

        _productItemRepository.UpdateProductItem(productItem);
        _productItemRepository.SaveChanges();
        return NoContent();
    }

    // DELETE: api/productitems/{id}
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteProductItem(Guid id)
    {
        _productItemRepository.DeleteProductItem(id);
        _productItemRepository.SaveChanges();
        return NoContent();
    }
}
