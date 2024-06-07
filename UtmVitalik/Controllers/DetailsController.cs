using System.Web.Mvc;

namespace UtmVitalik.Controllers
{
    public class DetailsController : Controller
    {
        [HttpGet]
        [Route("details")]
        public ActionResult Details()
        {
            return View();
        }
    }
}