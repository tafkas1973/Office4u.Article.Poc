using Microsoft.AspNetCore.Authorization;

namespace Office4U.Articles.Presentation.Controller.Controllers
{
    [Authorize(Policy = "RequireImportArticlesRole")]
    public class ImportController: BaseApiController
    {
        
    }
}