using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    public class RentalsController : Controller
    {
        [Route("rentals/new")]
        public ActionResult RentalForm()
        {
            return View();
        }
    }
}