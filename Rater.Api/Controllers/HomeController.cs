using Microsoft.AspNetCore.Mvc;
using Rater.Api.Data;
using Rater.Api.Models;
using System.Diagnostics;

namespace Rater.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISkillsDataStore dataStore;

        public HomeController(ISkillsDataStore dataStore)
        {
            this.dataStore = dataStore;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var skills = dataStore.Get();
            ViewData["MaxRating"] = 5;
            ViewData["Skills"] = skills;
            return View(new Skill());
        }


        [HttpPost]
        public IActionResult Index(Skill skill)
        {
            dataStore.Add(skill);
            return Redirect("/");
        }


        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}