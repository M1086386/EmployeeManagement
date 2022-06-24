using log4net;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private static log4net.ILog Log { get; set; } 
        ILog log = log4net.LogManager.GetLogger(typeof(HomeController));
        public ActionResult Index()
        {
            log.Info("This is an info message");
            log.Debug("Debug message");
            log.Warn("Warn message");
            log.Error("Error message");
            log.Fatal("Fatal message");

            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
