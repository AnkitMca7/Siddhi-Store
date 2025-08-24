using System;
using System.Collections.Generic;
using System.Linq;
using siddhi_store_backend.Data;
using siddhi_store_backend.Models;

public class ProductTypeRepository : IProductTypeRepository
{
    private readonly ApplicationDbContext _context;
    public ProductTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<ProductType> GetAllProductTypes()
    {
        return _context.ProductTypes.ToList();
    }

    public ProductType GetProductTypeById(Guid id)
    {
        return _context.ProductTypes.FirstOrDefault(pt => pt.Id == id);
    }

    public void AddProductType(ProductType productType)
    {
        if (productType == null) throw new ArgumentNullException(nameof(productType));
        _context.ProductTypes.Add(productType);
    }

    public void UpdateProductType(ProductType productType)
    {
        // EF Core tracks changes
    }

    public void DeleteProductType(Guid id)
    {
        var productType = GetProductTypeById(id);
        if (productType != null) _context.ProductTypes.Remove(productType);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}
