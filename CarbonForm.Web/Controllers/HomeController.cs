using System.Diagnostics;
using CarbonForm.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarbonForm.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
