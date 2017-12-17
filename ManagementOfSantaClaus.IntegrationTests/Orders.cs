using ManagementOfSantaClaus.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementOfSantaClaus.IntegrationTests
{
  [TestClass]
  public class Orders
  {
    private IMongoDatabase db;
    private string testId = ObjectId.GenerateNewId().ToString();

    [TestInitialize]
    public void Initialize()
    {
      MongoClientSettings settings = new MongoClientSettings();
      MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
      db = client.GetDatabase(MongoDBConfig.DBName);
      IMongoCollection<Order> collection = db.GetCollection<Order>("orders");
      collection.InsertOne(new Order
      {
        Id = testId,
        Kid = "test-kid",
        Status = StatusType.Done,
        Date = new DateTime(),
        Toys = new List<Toy>() 
      });
    }

    [TestCleanup]
    public void Cleanup()
    {
      if (db != null)
      {
        db.DropCollection("orders");
      }
    }

    [TestMethod]
    public void GetAllOrders_Should_Return_A_List()
    {
      var db = new Classes.MongoDB();
      var list = db.GetAllOrders();
      Assert.AreEqual(1, list.Count());
    }

    [TestMethod]
    public void GetOrder_Should_Return_Order()
    {
      var db = new Classes.MongoDB();
      var order = db.GetOrder(testId);
      Assert.IsNotNull(order);
    }

    [TestMethod]
    public void UpdateOrder_Should_Return_True()
    {
      var db = new Classes.MongoDB();
      var order = db.GetOrder(testId);
      order.Status = StatusType.InProgress;
      Assert.IsTrue(db.UpdateOrder(order));
    }
  }
}