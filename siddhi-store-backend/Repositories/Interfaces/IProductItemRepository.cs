using System;
using System.Collections.Generic;
using siddhi_store_backend.Models;

public interface IProductItemRepository
{
    IEnumerable<ProductItem> GetAllProductItems();
    ProductItem GetProductItemById(Guid id);
    void AddProductItem(ProductItem productItem);
    void UpdateProductItem(ProductItem productItem);
    void DeleteProductItem(Guid id);
    bool SaveChanges();
}
