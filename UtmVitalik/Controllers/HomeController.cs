using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using UtmVitalik.BusinessLogic.DB;

namespace UtmVitalik.Controllers
{
 
    public class HomeController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        
        
        [HttpGet]
        [Route("home")]
        public ActionResult Index()
        {
            try
            {
                db.Database.Connection.Open();
                Console.WriteLine("Connection State: " + db.Database.Connection.State);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Exception: " + ex.Message);
                Console.WriteLine("SQL Inner Exception: " + ex.InnerException?.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Invalid Operation Exception: " + ex.Message);
                Console.WriteLine("Invalid Operation Inner Exception: " + ex.InnerException?.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception: " + ex.Message);
                Console.WriteLine("General Inner Exception: " + ex.InnerException?.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
            }
            return View();
        }
    }

    public class GameController : Controller
    {
        private ApplicationContext db;

        public GameController()
        {
            db = new ApplicationContext();
        }
        public ActionResult Index(string searchTerm)
        {
            var games = string.IsNullOrWhiteSpace(searchTerm)
                ? db.Games.ToList()
                : db.Games
                    .Where(g => g.Name.Contains(searchTerm))
                    .ToList();
            ViewBag.SearchQuery = searchTerm;
            return View(games);
        }
    }
}