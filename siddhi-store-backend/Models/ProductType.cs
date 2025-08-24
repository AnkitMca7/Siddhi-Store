using System;

namespace siddhi_store_backend.Models
{
    public class ProductType
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public ICollection<ProductItem> ProductItems { get; set; }
    }
}   
