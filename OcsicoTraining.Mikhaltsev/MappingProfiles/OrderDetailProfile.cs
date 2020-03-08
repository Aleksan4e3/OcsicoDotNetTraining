using AutoMapper;
using EntityModels;
using ViewModels;

namespace MappingProfiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetailViewModel, OrderDetail>()
                .ForMember(x => x.ProductId,
                    act => act.MapFrom(x => x.Id))
                .ForMember(x => x.Id,
                    act => act.Ignore());
        }
    }
}
