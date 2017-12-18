using ManagementOfSantaClaus.Models;
using System.Linq;
using System.Web.Mvc;

namespace ManagementOfSantaClaus.Controllers
{
  public class ToysController : Controller
  {
    public ActionResult Index()
    {
      if (Session["IsAdmin"] != null)
      {
        Classes.MongoDB db = new Classes.MongoDB();
        var toys = db.GetAllToys();
        Toys model = new Toys();
        model.ToysList = toys.ToList();
        return View(model);
      }
      else
      {
        return RedirectToAction("../Users/Login");
      }
    }

    public ActionResult MissingToy()
    {
      if (Session["IsAdmin"] != null)
      {
        Classes.MongoDB db = new Classes.MongoDB();
        var toys = db.GetAllToys();
        Toys model = new Toys();
        model.ToysList = toys.ToList();
        return View(model);
      }
      else
      {
        return RedirectToAction("../Users/Login");
      }
    }
  }
}