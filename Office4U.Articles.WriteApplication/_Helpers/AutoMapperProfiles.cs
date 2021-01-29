using AutoMapper;
using Office4U.Articles.WriteApplication.Article.DTOs;

namespace Office4U.Articles.WriteApplication.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ArticleForUpdateDto, Domain.Model.Entities.Articles.Article>();
            CreateMap<ArticleForCreationDto, Domain.Model.Entities.Articles.Article>();
            //CreateMap<Article, ArticleForReturnDto>();

            //CreateMap<RegisterDto, AppUser>();
        }
    }
}