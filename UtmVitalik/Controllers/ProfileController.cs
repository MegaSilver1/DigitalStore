using System.Web.Mvc;

namespace UtmVitalik.Controllers
{
    public class ProfileController : Controller
    {
        public ProfileController()
        {
            
        }

        [HttpGet]
        [Route("profile/{userName}")]
        public ActionResult UserProfile(string userName)
        {
            ViewBag.Username = userName;
            return View();
        }
    }
}