using System;

namespace siddhi_store_backend.Models
{
    public class SubProduct
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public ICollection<ProductItem> ProductItems { get; set; } = new List<ProductItem>();
    }
}
