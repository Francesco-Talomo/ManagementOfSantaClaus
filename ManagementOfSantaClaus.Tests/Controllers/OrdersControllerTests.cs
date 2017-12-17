using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagementOfSantaClaus.Controllers;

namespace ManagementOfSantaClaus.Tests.Controllers
{
  class OrdersControllerTests
  {
    [TestMethod]
    public void Index()
    {
      OrdersController controller = new OrdersController();
      ViewResult result = controller.Index() as ViewResult;
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Edit()
    {
      string id = "1";
      OrdersController controller = new OrdersController();
      ViewResult result = controller.Edit(id) as ViewResult;
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Details()
    {
      string id = "1";
      OrdersController controller = new OrdersController();
      ViewResult result = controller.Details(id) as ViewResult;
      Assert.IsNotNull(result);
    }
  }
}
