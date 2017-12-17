using ManagementOfSantaClaus.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ManagementOfSantaClaus.IntegrationTests
{
  [TestClass]
  public class Users
  {
    private IMongoDatabase db;
    private string testId = ObjectId.GenerateNewId().ToString();
    private const string TEST_SCREEN_NAME = "test-screenName";
    private const string TEST_PASSWORD = "test-password";
    private const string TEST_PASSWORD_CLEAR = "test-password-clear";
    private const string TEST_EMAIL = "test-email";
    private const bool TEST_ISADMIN = true;

    [TestInitialize]
    public void Initialize()
    {
      MongoClientSettings settings = new MongoClientSettings();
      MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
      db = client.GetDatabase(MongoDBConfig.DBName);
      IMongoCollection<User> collection = db.GetCollection<User>("users");
      collection.InsertOne(new User
      {
        Id = testId,
        ScreenName = TEST_SCREEN_NAME,
        Email = TEST_EMAIL,
        IsAdmin = TEST_ISADMIN,
        Password = TEST_PASSWORD,
        PasswordClearText = TEST_PASSWORD_CLEAR
      });
    }

    [TestCleanup]
    public void Cleanup()
    {
      if (db != null)
      {
        db.DropCollection("users");
      }
    }

    [TestMethod]
    public void GetUser_Should_Return_User()
    {
      var db = new Classes.MongoDB();
      var test = new User
      {
        ScreenName = TEST_SCREEN_NAME,
        Email = TEST_EMAIL,
        IsAdmin = TEST_ISADMIN,
        Password = TEST_PASSWORD,
        PasswordClearText = TEST_PASSWORD_CLEAR
      };
      var user = db.GetUser(test);
      Assert.IsNotNull(user);
    }
  }
}