using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Service.Models;

namespace Service.Controllers
{
    public class Home2Controller : Controller
    {

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
