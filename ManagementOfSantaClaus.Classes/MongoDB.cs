using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementOfSantaClaus.Classes
{
  public class MongoDB : IDataBase
  {
    private IMongoDatabase database
    {
      get
      {
        return MongoConnection.Instance.Database;
      }
    }

    public IEnumerable<Order> GetAllOrder()
    {
      IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
      return orderCollection.Find(new BsonDocument()).SortByDescending(t => t.Date).ToList();
    }

    public IEnumerable<Toy> GetAllToy()
    {
      IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toys");
      return toyCollection.Find(new BsonDocument()).ToList();
    }

    public Order GetOrder(string id)
    {
      IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
      return orderCollection.Find(_ => _.ID == id).FirstOrDefault();
    }

    public Toy GetToy(string id)
    {
      IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toys");
      return toyCollection.Find(_ => _.ID == id).FirstOrDefault();
    }

    public User GetUser(User user)
    {
      IMongoCollection<User> userCollection = database.GetCollection<User>("users");
      return userCollection.Find(new BsonDocument()).FirstOrDefault();
      //return userCollection.Find(_ => _.ScreenName == user.ScreenName && _.Password == user.Password).FirstOrDefault();
    }

    public bool UpdateOrder(Order order)
    {
      IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
      var filter = Builders<Order>.Filter.Eq("_id", ObjectId.Parse(order.ID));
      var update = Builders<Order>.Update
          .Set("kid", order.Kid)
          .Set("status", order.Status)
          .Set("toy", order.Toys)
          .Set("requestDate", order.Date);
      try
      {
        orderCollection.UpdateOne(filter, update);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public bool UpdateToy(Toy toy)
    {
      IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toys");
      var filter = Builders<Toy>.Filter.Eq("_id", ObjectId.Parse(toy.ID));
      var update = Builders<Toy>.Update
          .Set("name", toy.Name)
          .Set("cost", toy.Cost)
          .Set("amount", toy.Amount);
      try
      {
        toyCollection.UpdateOne(filter, update);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
