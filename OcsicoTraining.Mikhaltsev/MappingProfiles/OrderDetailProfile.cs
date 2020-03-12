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
                .ForMember(x => x.Product, act => act.Ignore());

            CreateMap<OrderDetail, OrderDetailViewModel>();
        }
    }
}
