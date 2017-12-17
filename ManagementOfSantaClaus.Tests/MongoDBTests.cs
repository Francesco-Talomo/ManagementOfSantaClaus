using ManagementOfSantaClaus.Classes;
using ManagementOfSantaClaus.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace ManagementOfSantaClaus.Tests
{
  [TestClass]
  public class MongoDBTests
  {
    [TestMethod]
    public void Update_Order_Should_Return_True()
    {
      Mock<IDataBase> mock = new Mock<IDataBase>();
      mock.Setup(m => m.UpdateOrder(It.IsAny<Order>())).Returns(true);
      Assert.IsTrue(mock.Object.UpdateOrder(new Order()));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Update_Order_Should_Throw_Exception_When_Order_Is_Null()
    {
      Mock<IDataBase> mock = new Mock<IDataBase>();
      mock.Setup(m => m.UpdateOrder(It.Is<Order>(order => order == null))).Throws<ArgumentNullException>();
      mock.Object.UpdateOrder(null);
    }

    [TestMethod]
    public void Update_Toy_Should_Return_True()
    {
      Mock<IDataBase> mock = new Mock<IDataBase>();
      mock.Setup(m => m.UpdateToy(It.IsAny<Toy>())).Returns(true);
      Assert.IsTrue(mock.Object.UpdateToy(new Toy()));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Update_Toy__Should_Throw_Exception_When_Order_Is_Null()
    {
      Mock<IDataBase> mock = new Mock<IDataBase>();
      mock.Setup(m => m.UpdateToy(It.Is<Toy>(toy => toy == null))).Throws<ArgumentNullException>();
      mock.Object.UpdateToy(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetUser_Should_Throw_Exception_When_User_Is_Null()
    {
      Mock<IDataBase> mock = new Mock<IDataBase>();
      mock.Setup(m => m.GetUser(It.Is<User>(user => user == null))).Throws<ArgumentNullException>();
      mock.Object.GetUser(null);
    }

    [TestMethod]
    public void GetUser_Should_Return_An_Object_Of_Type_User()
    {
      Mock<IDataBase> mock = new Mock<IDataBase>();
      mock.Setup(m => m.GetUser(It.IsAny<User>())).Returns(new User());
      User result = mock.Object.GetUser(new User());
      Assert.IsInstanceOfType(result, typeof(User));
    }

    [TestMethod]
    public void GetAllOrders_Should_Return_An_IEnumerable_Of_Order()
    {
      Mock<IDataBase> mock = new Mock<IDataBase>();
      mock.Setup(m => m.GetAllOrders()).Returns(new List<Order>());
      var results = mock.Object.GetAllOrders();
      Assert.IsInstanceOfType(results, typeof(IEnumerable<Order>));
    }

    [TestMethod]
    public void GetAllToys_Should_Return_An_IEnumerable_Of_Toy()
    {
      Mock<IDataBase> mock = new Mock<IDataBase>();
      mock.Setup(m => m.GetAllToys()).Returns(new List<Toy>());
      var results = mock.Object.GetAllToys();
      Assert.IsInstanceOfType(results, typeof(IEnumerable<Toy>));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetOrder_Should_Throw_Exception_When_id_Is_Null()
    {
      Mock<IDataBase> mock = new Mock<IDataBase>();
      mock.Setup(m => m.GetOrder(It.Is<string>(id => id == null))).Throws<ArgumentNullException>();
      mock.Object.GetOrder(null);
    }

    [TestMethod]
    public void GetOrder_Should_Return_An_Object_Of_Type_Order()
    {
      Mock<IDataBase> mock = new Mock<IDataBase>();
      mock.Setup(m => m.GetOrder(It.Is<string>(id => id == "1"))).Returns(new Order());
      Order result = mock.Object.GetOrder(It.Is<string>(id => id == "1"));
      Assert.IsInstanceOfType(result, typeof(Order));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetToy_Should_Throw_Exception_When_id_Is_Null()
    {
      Mock<IDataBase> mock = new Mock<IDataBase>();
      mock.Setup(m => m.GetToy(It.Is<string>(id => id == null))).Throws<ArgumentNullException>();
      mock.Object.GetToy(null);
    }

    [TestMethod]
    public void GetToy_Should_Return_An_Object_Of_Type_Toy()
    {
      Mock<IDataBase> mock = new Mock<IDataBase>();
      mock.Setup(m => m.GetToy(It.Is<string>(id => id == "1"))).Returns(new Toy());
      Toy result = mock.Object.GetToy(It.Is<string>(id => id == "1"));
      Assert.IsInstanceOfType(result, typeof(Toy));
    }
  }
}