using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using UtmVitalik.BusinessLogic.DB;

namespace UtmVitalik.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        [HttpGet]
        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hashedPassword = HashPassword(model.Password);
                var user = db.Actor.FirstOrDefault(u => u.Name == model.Name && u.Password == hashedPassword);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("userProfile", "Profile", new {userName = user.Name});
                }

                ModelState.AddModelError("", "Неудачная попытка входа");

            }
            return View(model);
        }
    

    public string HashPassword(string password)
            {
                using (var sha256 = SHA256.Create())
                {
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                }
            }
        }
    }