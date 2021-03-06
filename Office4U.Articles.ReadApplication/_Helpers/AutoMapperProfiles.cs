using AutoMapper;
using Office4U.Articles.Domain.Model.Entities.Articles;
using Office4U.Articles.ReadApplication.Article.DTOs;
using System.Linq;

namespace Office4U.Articles.ReadApplication.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<AppUser, AppUserDto>();

            CreateMap<Domain.Model.Entities.Articles.Article, ArticleDto>()
                .ForMember(
                    dest => dest.PhotoUrl,
                    options => options.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));

            CreateMap<ArticlePhoto, ArticlePhotoDto>();
        }
    }
}