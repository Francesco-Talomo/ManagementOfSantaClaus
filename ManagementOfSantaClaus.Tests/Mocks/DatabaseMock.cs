using System.Collections.Generic;
using ManagementOfSantaClaus.Classes;

namespace ManagementOfSantaClaus.Tests.Mocks
{
  class DataBaseMock : IDataBase
  {
    public IEnumerable<Order> GetAllOrders()
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Toy> GetAllToys()
    {
      throw new System.NotImplementedException();
    }

    public Order GetOrder(string id)
    {
      throw new System.NotImplementedException();
    }

    public Toy GetToy(string id)
    {
      throw new System.NotImplementedException();
    }

    public User GetUser(User user)
    {
      throw new System.NotImplementedException();
    }

    public bool UpdateOrder(Order order)
    {
      throw new System.NotImplementedException();
    }

    public bool UpdateToy(Toy toy)
    {
      throw new System.NotImplementedException();
    }
  }
}