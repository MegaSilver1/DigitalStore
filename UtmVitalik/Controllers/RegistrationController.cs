using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using Microsoft.Win32.SafeHandles;
using UtmVitalik.BusinessLogic.DB;

namespace UtmVitalik.Controllers
{
    public class RegistrationController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        [HttpGet]
        [Route("registration")]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegisterViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                var actor = new Actor
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = HashPassword(model.Password)
                };
                db.Actor.Add(actor);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
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