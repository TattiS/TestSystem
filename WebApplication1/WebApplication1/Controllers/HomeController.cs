using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestSystemApi.Models;

namespace TestSystemApi.Controllers
{
    public class HomeController : Controller
    {
        private static int numberOfTests=0;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
           
            ViewData["Message"] = "It's  a placement test. Let's try to figure out your level of English. Good luck!";
           Test newTest = new Test();
            newTest.SeedQuestions(@"C:\Users\tanya\source\repos\WebApplication1\WebApplication1\Source\seeds.json");
            numberOfTests = newTest.Questions.Count;
            return View(newTest.Questions);
        }

        [HttpPost]
        public IActionResult Result(IFormCollection form)
        {
            int score = 0;
            for (int i = 1; i < numberOfTests+1; i++)
            {
              string name = i.ToString();
                if (!string.IsNullOrEmpty(form[name]))
                {
                    var result = form[name].First();
                    if (result == "value")
                    {
                        score++;
                    }
                }
            }

            ViewBag.Score = score;

            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
