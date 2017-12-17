using ManagementOfSantaClaus.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace ManagementOfSantaClaus.IntegrationTests
{
  [TestClass]
  public class Toys
  {
    private IMongoDatabase db;
    private string testId = ObjectId.GenerateNewId().ToString();
    private const string TEST_TOY_NAME = "test-toy";
    private const int TEST_TOY_AMOUNT = 10;
    private const decimal TEST_TOY_COST = 15;

    [TestInitialize]
    public void Initialize()
    {
      MongoClientSettings settings = new MongoClientSettings();
      MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
      db = client.GetDatabase(MongoDBConfig.DBName);
      IMongoCollection<Toy> collection = db.GetCollection<Toy>("toys");
      collection.InsertOne(new Toy
      {
        Id = testId,
        Name = TEST_TOY_NAME,
        Amount = TEST_TOY_AMOUNT,
        Cost = TEST_TOY_COST
      });
    }

    [TestCleanup]
    public void Cleanup()
    {
      if (db != null)
      {
        db.DropCollection("toys");
      }
    }

    [TestMethod]
    public void GetToy_Should_Return_Toy()
    {
      var db = new Classes.MongoDB();
      var toy = db.GetToy(testId);
      Assert.IsNotNull(toy);
    }

    [TestMethod]
    public void GetAllToys_Should_Return_A_List()
    {
      var db = new Classes.MongoDB();
      var list = db.GetAllToys();
      Assert.AreEqual(1, list.Count());
    }
  }
}