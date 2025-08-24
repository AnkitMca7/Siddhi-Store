using System;
using System.Collections.Generic;
using siddhi_store_backend.Models;


namespace siddhi_store_backend.Models
{

    
        public class Product
        {
            public Guid Id { get; set; } = Guid.NewGuid();
            public string Name { get; set; }

            public ICollection<SubProduct> SubProducts { get; set; }
            public ICollection<ProductItem> ProductItems { get; set; }
        }
    }

