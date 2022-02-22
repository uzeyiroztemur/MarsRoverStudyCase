using MarsRoverStudyCase.Helpers;
using MarsRoverStudyCase.Models;
using MarsRoverStudyCase.Models.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MarsRoverStudyCase.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public CaseModel StudyCase { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ViewData["Result"] = new ResponseData();
        }

        public void OnPost(CaseModel StudyCase)
        {
            ViewData["Status"] = CaseHelper.Calculate(StudyCase);
        }
    }
}
