using System;
using System.Collections.Generic;
using siddhi_store_backend.Models;

public interface ISubProductRepository
{
    IEnumerable<SubProduct> GetAllSubProducts();
    SubProduct GetSubProductById(Guid id);
    void AddSubProduct(SubProduct subProduct);
    void UpdateSubProduct(SubProduct subProduct);
    void DeleteSubProduct(Guid id);
    bool SaveChanges();
}
