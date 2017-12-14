using ManagementOfSantaClaus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementOfSantaClaus.Controllers
{
  public class ToysController : Controller
  {
    public ActionResult Index()
    {
      Classes.MongoDB db = new Classes.MongoDB();
      var toys = db.GetAllToy();
      Toys model = new Toys();
      model.EntityList = toys.ToList();
      return View(model);
    }
  }
}