using AutoMapper;
using Office4U.Articles.Common;
using Office4U.Articles.Data.Ef.SqlServer.Interfaces;
using Office4U.Articles.ReadApplication.Article.DTO;
using Office4U.Articles.ReadApplication.Article.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Office4U.Articles.ReadApplication.Article.Queries
{
    // TODO: implement MediatR ?

    public class GetArticlesListQuery : IGetArticlesListQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetArticlesListQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<ArticleDto>> Execute(ArticleParams articleParams)
        {
            var articles = await _unitOfWork.ArticleRepository.GetArticlesAsync(articleParams);

            // TODO: Move AutoMapper to ReadApplication
            //var articlesDtos = _mapper.Map<IEnumerable<ArticleDto>>(articles);

            var articlesDtos = articles.Select(a => new ArticleDto()
            {
                Id = a.Id,
                Code = a.Code,
                SupplierId = a.SupplierId,
                SupplierReference = a.SupplierReference,
                Name1 = a.Name1,
                Unit = a.Unit,
                PurchasePrice = a.PurchasePrice,
                PhotoUrl = a.Photos.Any() ? a.Photos.First().Url : string.Empty,
                Photos = a.Photos.Select(p => new DTOs.ArticlePhotoDto()
                {
                    Id = p.Id,
                    IsMain = p.IsMain,
                    Url = p.Url
                }).ToList()
            });

            var articlesToReturn = new PagedList<ArticleDto>(articlesDtos, articles.TotalCount, articles.CurrentPage, articles.PageSize);

            return articlesToReturn;
        }
    }
}
