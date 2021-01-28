using AutoMapper;
using Office4U.Articles.Domain.Model.Entities;
using Office4U.Articles.ReadApplication.Article.DTOs;
using System.Linq;

namespace Office4U.Articles.Data.Ef.SqlServer
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<AppUser, AppUserDto>();

            CreateMap<Article, ArticleDto>()
                .ForMember(
                    dest => dest.PhotoUrl,
                    options => options.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<ArticlePhoto, ArticlePhotoDto>();
        }
    }
}