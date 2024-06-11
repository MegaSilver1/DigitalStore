using System;
using System.Web.Mvc;
using UtmVitalik.BusinessLogic.DB;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Helpers;

namespace UtmVitalik.Controllers
{
    public class AdministrationController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        [Authorize(Roles = "Admin")]
        public ActionResult Administration()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetUsers()
        {
            var users = db.Actor.Select(u => new
            {
                u.Id,
                u.Name,
                u.Email,
                u.Role
            }).ToList();

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        
        [HttpPost]
        public ActionResult UpdateUser(int id, string role, string password)
        {
            try
            {
                var user = db.Actor.Find(id);
                if (user != null)
                {
                    user.Role = role;
                    user.Password = HashPassword(password);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "User not found" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        
        public ActionResult DeleteUser(int id)
        {
            try
            {
                var user = db.Actor.Find(id);
                if (user != null)
                {
                    db.Actor.Remove(user);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "User not found" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        
       
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}