using System;
using System.Collections.Generic;
using siddhi_store_backend.Models;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(Guid id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Guid id);
    bool SaveChanges();
}
