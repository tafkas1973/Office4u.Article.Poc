using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Office4U.Articles.Common;
//using Office4U.Articles.Data.Ef.SqlServer.Interfaces;  // TODO: refactor : THIS IS NOT ALLOWED !!!
using Office4U.Articles.Presentation.Controller.Controllers.DTOs.Article;
using Office4U.Articles.Presentation.Controller.Extensions;
using Office4U.Articles.ReadApplication.Article.DTOs;
using Office4U.Articles.ReadApplication.Article.Interfaces;
using Office4U.Articles.WriteApplication.Article.DTOs;
using Office4U.Articles.WriteApplication.Article.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Office4U.Articles.Presentation.Controller.Controllers
{
    [Authorize(Policy = "RequireManageArticlesRole")]
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IGetArticlesListQuery _listQuery;
        private readonly IGetArticleQuery _singleQuery;
        private readonly ICreateArticleCommand _createCommand;
        private readonly IUpdateArticleCommand _updateCommand;
        private readonly IDeleteArticleCommand _deleteCommand;

        public ArticlesController(
            IGetArticlesListQuery listQuery,
            IGetArticleQuery singleQuery,
            ICreateArticleCommand createCommand,
            IUpdateArticleCommand updateCommand,
            IDeleteArticleCommand deleteCommand
            )
        {
            _listQuery = listQuery;
            _singleQuery = singleQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetArticles(
            [FromQuery] ArticleParams articleParams)
        {
            var articles = await _listQuery.Execute(articleParams);

            Response.AddPaginationHeader(articles.CurrentPage, articles.PageSize, articles.TotalCount, articles.TotalPages);

            return Ok(articles.AsEnumerable());
        }

        [HttpGet("{id}", Name = "GetArticle")]
        public async Task<ActionResult<ArticleDto>> GetArticle(int id)
        {
            return Ok(await _singleQuery.Execute(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(ArticleForCreationDto articleForCreationDto)
        {
            await _createCommand.Execute(articleForCreationDto);

            return Ok();

            // TODO: handle errors & return correct status

            //if (await _unitOfWork.Commit())
            //{
            //    var articleToReturn = _mapper.Map<ArticleForReturnDto>(newArticle);
            //    return CreatedAtRoute("GetArticle", new { id = newArticle.Id }, articleToReturn);
            //}

            //return BadRequest("Failed to create article");
        }

        [HttpPut]
        // TODO: restful: also specify id in parm list?
        public async Task<ActionResult> UpdateArticle(ArticleForUpdateDto articleUpdateDto)
        {
            await _updateCommand.Execute(articleUpdateDto);

            return NoContent();

            // TODO: handle errors

            //if (await _unitOfWork.Commit()) return NoContent();

            //return BadRequest("Failed to update article");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _deleteCommand.Execute(id);

            return Ok();

            // TODO: handle errors

            //if (await _unitOfWork.Commit())
            //    return Ok();

            //return BadRequest("Failed to delete article");
        }
    }
}