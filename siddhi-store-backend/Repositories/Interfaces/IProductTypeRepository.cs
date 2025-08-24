using System;
using System.Collections.Generic;
using siddhi_store_backend.Models;

public interface IProductTypeRepository
{
    IEnumerable<ProductType> GetAllProductTypes();
    ProductType GetProductTypeById(Guid id);
    void AddProductType(ProductType productType);
    void UpdateProductType(ProductType productType);
    void DeleteProductType(Guid id);
    bool SaveChanges();
}
