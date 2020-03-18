using AutoMapper;
using EntityModels;
using ViewModels;

namespace MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductViewModel, Product>()
                .ForMember(x => x.ParentProductId,
                    act => act.MapFrom(src => src.SelectedParentId))
                .ForMember(x => x.ImageUrl, act => act.Ignore());

            CreateMap<Product, CreateProductViewModel>()
                .ForMember(x => x.SelectedParentId,
                    act => act.MapFrom(src => src.ParentProductId))
                .ForMember(x => x.Image, act => act.Ignore());

            CreateMap<Product, ProductViewModel>();

            CreateMap<ProductViewModel, Product>();

            CreateMap<Product, OrderDetailViewModel>()
                .ForMember(x => x.Product,
                    act => act.MapFrom(src => src))
                .ForMember(x => x.ProductId,
                    act => act.MapFrom(src => src.Id));
        }
    }
}
