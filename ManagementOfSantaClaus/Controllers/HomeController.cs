using System.Web.Mvc;

namespace ManagementOfSantaClaus.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "About";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Contact";

      return View();
    }
  }
}