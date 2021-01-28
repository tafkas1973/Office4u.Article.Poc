using Microsoft.AspNetCore.Authorization;

namespace Office4U.Articles.Presentation.Controller.Controllers
{
    [Authorize(Policy = "RequireExportArticlesRole")]
    public class ExportController: BaseApiController
    {
        
    }
}