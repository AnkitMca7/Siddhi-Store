using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using siddhi_store_backend.Models;
using System;

[ApiController]
[Route("api/[controller]")]
public class ProductTypesController : ControllerBase
{
    private readonly IProductTypeRepository _productTypeRepository;

    public ProductTypesController(IProductTypeRepository productTypeRepository)
    {
        _productTypeRepository = productTypeRepository;
    }

    // GET: api/producttypes
    [HttpGet]
    public IActionResult GetAll()
    {
        var productTypes = _productTypeRepository.GetAllProductTypes();
        return Ok(productTypes);
    }

    // GET: api/producttypes/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var productType = _productTypeRepository.GetProductTypeById(id);
        if (productType == null)
            return NotFound();
        return Ok(productType);
    }

    // POST: api/producttypes
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult AddProductType(ProductType productType)
    {
        _productTypeRepository.AddProductType(productType);
        _productTypeRepository.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = productType.Id }, productType);
    }

    // PUT: api/producttypes/{id}
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateProductType(Guid id, ProductType productType)
    {
        if (id != productType.Id)
            return BadRequest();

        _productTypeRepository.UpdateProductType(productType);
        _productTypeRepository.SaveChanges();
        return NoContent();
    }

    // DELETE: api/producttypes/{id}
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteProductType(Guid id)
    {
        _productTypeRepository.DeleteProductType(id);
        _productTypeRepository.SaveChanges();
        return NoContent();
    }
}
