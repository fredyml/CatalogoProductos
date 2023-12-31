﻿using System.Text.Json.Serialization;

namespace CatalogoProductos.Aplication.Dtos
{
    public class ProductDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? ProductImageUrl { get; set; }
    }
}
