using AutoMapper;
using Office4U.Articles.Data.Ef.SqlServer.Interfaces;
using Office4U.Articles.ReadApplication.Article.DTOs;
using Office4U.Articles.ReadApplication.Article.Interfaces;
using System.Threading.Tasks;

namespace Office4U.Articles.ReadApplication.Article.Queries
{
    // TODO: implement MediatR ?

    public class GetArticleQuery : IGetArticleQuery
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetArticleQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ArticleDto> Execute(int id)
        {
            var article = await _unitOfWork.ArticleRepository.GetArticleByIdAsync(id);

            var articleDto = _mapper.Map<ArticleDto>(article);

            return articleDto;
        }
    }
}
