using AutoMapper;
using EntityModels;
using ViewModels;

namespace MappingProfiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<CreateArticleViewModel, Article>()
                .ForMember(x => x.ImageUrl, act => act.Ignore());
        }
    }
}
