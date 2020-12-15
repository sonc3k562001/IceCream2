using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Ice_Cream.Models;
using Ice_Cream.Models.ViewModels;

namespace Ice_Cream.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


