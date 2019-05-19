using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ADWebApp.Models;
using ADWebApp.Services;
using Microsoft.Extensions.Configuration;

namespace ADWebApp.Controllers
{
    [Authorize]
    public  class HomeController : Controller
    {
        public async  Task<IActionResult> Index([FromServices] IConfiguration configuration)
        {
            return View();
            //var client = new ADWebAPIClient(configuration);
            //await client.Initialize();

            //var result = await client.GetValuesAsync();
            //return Content(result);



        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
