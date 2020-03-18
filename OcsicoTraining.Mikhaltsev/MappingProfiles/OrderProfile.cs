using AutoMapper;
using EntityModels;
using ViewModels;

namespace MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderViewModel, Order>()
                .ForMember(x => x.Id, act => act.Ignore())
                .ForMember(x => x.User, act => act.Ignore());

            CreateMap<Order, OrderViewModel>();
        }
    }
}
