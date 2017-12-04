using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();
            //ViewBag.jobs = jobs;

            if(string.IsNullOrEmpty(searchTerm))
            {
                return View("index");
            }           
            if (searchType == "all")
            {
                jobs = JobData.FindByValue(searchTerm);               
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);               
            }
            ViewBag.jobs = jobs;
            return View("Index");
        }
        // TODO #1 - Create a Results action method to process 
        // search request and display results
    }
}
