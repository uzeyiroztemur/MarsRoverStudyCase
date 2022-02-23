using System.Collections.Generic;
using MarsRoverStudyCase.Helpers;
using MarsRoverStudyCase.Models;
using MarsRoverStudyCase.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
            var values = new List<string>();
            var res = CaseHelper.Calculate(StudyCase);
            if (res.Status == Models.Enums.StatusEnum.Success)
            {
                if (HttpContext.Session.GetString("ResultList") != null)
                    values = JsonConvert.DeserializeObject<List<string>>(HttpContext.Session.GetString("ResultList"));

                res.Data.InsertRange(0, values);
                HttpContext.Session.SetString("ResultList", JsonConvert.SerializeObject(res.Data));
            }
            ViewData["Result"] = res;
        }
    }
}
