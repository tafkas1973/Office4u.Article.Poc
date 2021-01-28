using Office4U.Articles.Data.Ef.SqlServer.Interfaces;
using Office4U.Articles.ReadApplication.Article.DTO;
using Office4U.Articles.ReadApplication.Article.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Office4U.Articles.ReadApplication.Article.Queries
{
    // TODO: implement MediatR ?

    public class GetArticleQuery : IGetArticleQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetArticleQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ArticleDto> Execute(int id)
        {
            var article = await _unitOfWork.ArticleRepository.GetArticleByIdAsync(id);

            // TODO mapper in application read 
            // var articleToReturn = _mapper.Map<ArticleDto>(article);

            var articleDto = new ArticleDto()
            {
                Id = article.Id,
                Code = article.Code,
                SupplierId = article.SupplierId,
                SupplierReference = article.SupplierReference,
                Name1 = article.Name1,
                Unit = article.Unit,
                PurchasePrice = article.PurchasePrice,
                PhotoUrl = article.Photos.Any() ? article.Photos.First().Url : string.Empty,
                Photos = article.Photos.Select(p => new DTOs.ArticlePhotoDto()
                {
                    Id = p.Id,
                    IsMain = p.IsMain,
                    Url = p.Url
                }).ToList()
            };

            return articleDto;
        }
    }
}
