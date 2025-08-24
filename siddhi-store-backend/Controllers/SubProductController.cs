using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using siddhi_store_backend.Models;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class SubProductsController : ControllerBase
{
    private readonly ISubProductRepository _subProductRepository;

    public SubProductsController(ISubProductRepository subProductRepository)
    {
        _subProductRepository = subProductRepository;
    }

    // GET: api/subproducts
    [HttpGet]
    public IActionResult GetAll()
    {
        var subProducts = _subProductRepository.GetAllSubProducts();
        return Ok(subProducts);
    }

    // GET: api/subproducts/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var subProduct = _subProductRepository.GetSubProductById(id);
        if (subProduct == null)
            return NotFound();
        return Ok(subProduct);
    }

    // POST: api/subproducts
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult AddSubProduct(SubProduct subProduct)
    {
        _subProductRepository.AddSubProduct(subProduct);
        _subProductRepository.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = subProduct.Id }, subProduct);
    }

    // PUT: api/subproducts/{id}
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateSubProduct(Guid id, SubProduct subProduct)
    {
        if (id != subProduct.Id)
            return BadRequest();

        _subProductRepository.UpdateSubProduct(subProduct);
        _subProductRepository.SaveChanges();
        return NoContent();
    }

    // DELETE: api/subproducts/{id}
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteSubProduct(Guid id)
    {
        _subProductRepository.DeleteSubProduct(id);
        _subProductRepository.SaveChanges();
        return NoContent();
    }
}
