using Office4U.Articles.Data.Ef.SqlServer.Interfaces;
using Office4U.Articles.WriteApplication.Article.DTOs;
using Office4U.Articles.WriteApplication.Article.Interfaces;
using System.Threading.Tasks;

namespace Office4U.Articles.WriteApplication.Article.Commands
{
    public class UpdateArticleCommand : IUpdateArticleCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateArticleCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(ArticleForUpdateDto articleForUpdate)
        {
            Domain.Model.Entities.Article article = await _unitOfWork.ArticleRepository.GetArticleByIdAsync(articleForUpdate.Id);

            // TODO mapping via DI !!           
            //mapper.Map(articleForUpdate, article);

            article.SupplierId = articleForUpdate.SupplierId;
            article.SupplierReference = articleForUpdate.SupplierReference;
            article.Name1 = articleForUpdate.Name1;
            article.PurchasePrice = articleForUpdate.PurchasePrice;

            _unitOfWork.ArticleRepository.Update(article);

            await _unitOfWork.Commit();

            // evt. notifications

            // TODO: handle errors ?
            // if (await _unitOfWork.Commit()) return NoContent();

            // return BadRequest("Failed to update article");
        }
    }
}
