using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
       
            int sum = 0;

            try
            {

                String[] fileName = System.IO.File.ReadAllLines("File.txt");

            foreach (string line in fileName)
                //  out argument. convert a string to a number.
                // 
                if (Int32.TryParse(line, out int number)) {
                    sum += number;
                }

            ViewBag.SourceOfData = fileName;
            ViewBag.CalculatedSum = sum;

            }
            catch (System.IO.FileNotFoundException)
            {
                ViewBag.CalculatedSum = "File not found";
            }


            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
