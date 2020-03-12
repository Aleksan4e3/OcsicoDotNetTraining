using AutoMapper;
using EntityModels;
using ViewModels;

namespace MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderViewModel, Order>();

            CreateMap<Order, OrderViewModel>();
        }
    }
}
