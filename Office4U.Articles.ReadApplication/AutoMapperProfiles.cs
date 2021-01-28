using AutoMapper;
using Office4U.Articles.Domain.Model.Entities;
using Office4U.Articles.ReadApplication.Article.DTO;
using Office4U.Articles.ReadApplication.Article.DTOs;
using System.Linq;

namespace Office4U.Articles.ReadApplication.Article
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<AppUser, AppUserDto>();

            CreateMap<Domain.Model.Entities.Article, ArticleDto>()
                .ForMember(
                    dest => dest.PhotoUrl,
                    options => options.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<ArticlePhoto, ArticlePhotoDto>();
            //CreateMap<ArticleUpdateDto, Article>();
            //CreateMap<ArticleForCreationDto, Article>();
            //CreateMap<Article, ArticleForReturnDto>();

            //CreateMap<RegisterDto, AppUser>();
        }
    }
}