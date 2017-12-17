using ManagementOfSantaClaus.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace ManagementOfSantaClaus.Tests.Controllers
{
  public class UsersControllerTests
  {
    [TestMethod]
    public void Login()
    {
      UsersController controller = new UsersController();
      ViewResult result = controller.Login() as ViewResult;
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Logout()
    {
      UsersController controller = new UsersController();
      ViewResult result = controller.Logout() as ViewResult;
      Assert.IsNotNull(result);
    }
  }
}
