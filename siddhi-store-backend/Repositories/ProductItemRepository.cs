using System;
using System.Collections.Generic;
using System.Linq;
using siddhi_store_backend.Data;
using siddhi_store_backend.Models;

public class ProductItemRepository : IProductItemRepository
{
    private readonly ApplicationDbContext _context;
    public ProductItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<ProductItem> GetAllProductItems()
    {
        return _context.ProductItems.ToList();
    }

    public ProductItem GetProductItemById(Guid id)
    {
        return _context.ProductItems.FirstOrDefault(pi => pi.Id == id);
    }

    public void AddProductItem(ProductItem productItem)
    {
        if (productItem == null) throw new ArgumentNullException(nameof(productItem));
        _context.ProductItems.Add(productItem);
    }

    public void UpdateProductItem(ProductItem productItem)
    {
        // EF Core tracks changes
    }

    public void DeleteProductItem(Guid id)
    {
        var productItem = GetProductItemById(id);
        if (productItem != null) _context.ProductItems.Remove(productItem);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}
