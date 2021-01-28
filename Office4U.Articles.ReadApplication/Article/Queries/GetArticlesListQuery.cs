using AutoMapper;
using Office4U.Articles.Common;
using Office4U.Articles.Data.Ef.SqlServer.Interfaces;
using Office4U.Articles.ReadApplication.Article.DTOs;
using Office4U.Articles.ReadApplication.Article.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Office4U.Articles.ReadApplication.Article.Queries
{
    // TODO: implement MediatR ?

    public class GetArticlesListQuery : IGetArticlesListQuery
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetArticlesListQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<ArticleDto>> Execute(ArticleParams articleParams)
        {
            var articles = await _unitOfWork.ArticleRepository.GetArticlesAsync(articleParams);
          
            var articlesDtos = _mapper.Map<IEnumerable<ArticleDto>>(articles);

            var articlesToReturn = new PagedList<ArticleDto>(articlesDtos, articles.TotalCount, articles.CurrentPage, articles.PageSize);

            return articlesToReturn;
        }
    }
}
