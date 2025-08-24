using System;
using System.Collections.Generic;
using System.Linq;
using siddhi_store_backend.Data;
using siddhi_store_backend.Models;

public class SubProductRepository : ISubProductRepository
{
    private readonly ApplicationDbContext _context;
    public SubProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<SubProduct> GetAllSubProducts()
    {
        return _context.SubProducts.ToList();
    }

    public SubProduct GetSubProductById(Guid id)
    {
        return _context.SubProducts.FirstOrDefault(sp => sp.Id == id);
    }

    public void AddSubProduct(SubProduct subProduct)
    {
        if (subProduct == null) throw new ArgumentNullException(nameof(subProduct));
        _context.SubProducts.Add(subProduct);
    }

    public void UpdateSubProduct(SubProduct subProduct)
    {
        // EF Core tracks changes
    }

    public void DeleteSubProduct(Guid id)
    {
        var subProduct = GetSubProductById(id);
        if (subProduct != null) _context.SubProducts.Remove(subProduct);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}
