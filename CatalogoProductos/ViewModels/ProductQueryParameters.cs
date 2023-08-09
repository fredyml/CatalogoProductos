using CatalogoProductos.Aplication.Enums;

namespace CatalogoProductos.ViewModels
{
    public class ProductQueryParameters
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public OrderByOptions OrderBy { get; set; }
        public bool IsAscending { get; set; } = true;
    }
}
