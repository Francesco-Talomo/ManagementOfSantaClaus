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

    public IEnumerable<Order> GetAllOrders()
    {
      IMongoCollection<Order> ordersCollection = database.GetCollection<Order>("orders");
      List<Order> orders = ordersCollection.Find(new BsonDocument()).SortBy(o => o.Date).ToList();
      foreach (Order order in orders)
      {
        DoNotDuplicateToy(order);
      }
      return orders;
    }

    public IEnumerable<Toy> GetAllToys()
    {
      IMongoCollection<Toy> toysCollection = database.GetCollection<Toy>("toys");
      return toysCollection.Find(new BsonDocument()).SortByDescending(t => t.Name).ToList();
    }

    public Order GetOrder(string id)
    {
      IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
      Order order = orderCollection.Find(_ => _.Id == id).FirstOrDefault();
      return DoNotDuplicateToy(order);
    }

    public Toy GetToy(string id)
    {
      IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toys");
      return toyCollection.Find(_ => _.Id == id).FirstOrDefault();
    }

    public User GetUser(User user)
    {
      IMongoCollection<User> userCollection = database.GetCollection<User>("users");
      return userCollection.Find(_ => _.Email == user.Email && _.Password == user.Password).FirstOrDefault();
    }

    public bool UpdateOrder(Order order)
    {
      IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
      var filter = Builders<Order>.Filter.Eq("_id", ObjectId.Parse(order.Id));
      var update = Builders<Order>.Update
          .Set("status", order.Status);
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
      var filter = Builders<Toy>.Filter.Eq("name", toy.Name);
      var update = Builders<Toy>.Update
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

    public Order DoNotDuplicateToy(Order order)
    {
        bool toyIsNotDuplicated;
        List<Toy> toyList = new List<Toy>();
        foreach (Toy kidRequestToy in order.Toys)
        {
          toyIsNotDuplicated = true;
          foreach (Toy toy in toyList)
          {
            if (toy.Name.Equals(kidRequestToy.Name))
            {
              toyIsNotDuplicated = false;
              break;
            }
          }
          if (toyIsNotDuplicated)
            toyList.Add(kidRequestToy);
        }
        order.Toys = toyList;
        return order;
    }
  }
}
