using System.Web.Mvc;
using System.Web.Security;

namespace UtmVitalik.Controllers
{
    public class ProfileController : Controller
    {
        public ProfileController()
        {
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return  RedirectToAction("Index","Home");
        }

        [HttpGet]
        [Route("profile/{userName}")]
        public ActionResult UserProfile(string userName)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login","Login");
            }
            ViewBag.Username = userName;
            return View();
        }
    }
}