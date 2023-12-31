﻿using System.ComponentModel.DataAnnotations;

namespace CatalogoProductos.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ProductImageUrl { get; set; }
    }

}
