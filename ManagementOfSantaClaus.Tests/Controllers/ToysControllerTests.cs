using ManagementOfSantaClaus.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace ManagementOfSantaClaus.Tests.Controllers
{
  class ToysControllerTests
  {
    [TestMethod]
    public void Index()
    {
      ToysController controller = new ToysController();
      ViewResult result = controller.Index() as ViewResult;
      Assert.IsNotNull(result);
    }
  }
}
