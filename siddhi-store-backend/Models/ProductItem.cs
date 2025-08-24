using System;

namespace siddhi_store_backend.Models
{
    public class ProductItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public string Color { get; set; }
        public string AgeGroup { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid? SubProductId { get; set; }
        public SubProduct SubProduct { get; set; }

        public Guid? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
