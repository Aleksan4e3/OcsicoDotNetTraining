using AutoMapper;
using EntityModels;
using ViewModels;

namespace MappingProfiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetailViewModel, OrderDetail>();
        }
    }
}