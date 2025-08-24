using System;
using System.Collections.Generic;
using System.Linq;
using siddhi_store_backend.Data;
using siddhi_store_backend.Models;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    public Product GetProductById(Guid id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public void AddProduct(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        _context.Products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        // EF Core tracks changes, no code needed here
    }

    public void DeleteProduct(Guid id)
    {
        var product = GetProductById(id);
        if (product != null) _context.Products.Remove(product);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}
