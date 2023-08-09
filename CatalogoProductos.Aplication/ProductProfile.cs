using AutoMapper;
using CatalogoProductos.Aplication.Dtos;
using CatalogoProductos.Domain.Entities;

namespace CatalogoProductos.Aplication
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
