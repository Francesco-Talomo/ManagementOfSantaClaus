using ManagementOfSantaClaus.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ManagementOfSantaClaus.Controllers
{
    public class UsersController : Controller
    {
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Login(User user)
    {
      string Encrypt(string text)
      {
        byte[] data = Encoding.UTF8.GetBytes(text);
        byte[] resultHash;
        SHA512 shaM = new SHA512Managed();
        resultHash = shaM.ComputeHash(data);
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < resultHash.Length; i++)
        {
          result.Append(resultHash[i].ToString("X2"));
        }
        return result.ToString();
      }
      user.Password = Encrypt(user.Password);
      Classes.MongoDB db = new Classes.MongoDB();
      var usr = db.GetUser(user);

      if (usr != null)
      {
        Session["ScreenName"] = usr.ScreenName.ToString();
        Session["Id"] = usr.ID.ToString();
        Session["Password"] = Encrypt(user.Password);
        return RedirectToAction("../Home");
      }
      else
      {
        ModelState.AddModelError("", "Username or Password Error");
      }
      return View();
    }

    public ActionResult Logout()
    {
      if (Session["Id"] != null)
      {
        Session.Clear();
        return RedirectToAction("Logout");
      }
      return View();
    }
  }
}
