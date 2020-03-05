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
                    act => act.MapFrom(src => src.SelectedParentId));
            CreateMap<Product, CreateProductViewModel>()
                .ForMember(x => x.SelectedParentId,
                    act => act.MapFrom(src => src.ParentProductId));
        }
    }
}
