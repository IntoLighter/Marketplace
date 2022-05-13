using AutoMapper;
using Domain.Cart;
using Domain.Marketplace;
using Web.Areas.Cart;

namespace Web;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        CreateMap<CartProduct, CartVM>().IncludeMembers(s => s.Product);
        CreateMap<Product, CartVM>();
    }
}
