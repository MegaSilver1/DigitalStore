using System.Web.Mvc;

namespace UtmVitalik.Controllers
{
    public class BrowseController : Controller
    {
        [HttpGet]
        [Route("browse")]
        public ActionResult Browse()
        {
            return View();
        }
    }
}