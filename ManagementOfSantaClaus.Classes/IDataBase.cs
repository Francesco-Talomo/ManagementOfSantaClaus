using System.Collections.Generic;

namespace ManagementOfSantaClaus.Classes
{
  public interface IDataBase
  {
    bool UpdateToy(Toy toy);

    bool UpdateOrder(Order order);

    IEnumerable<Toy> GetAllToy();

    IEnumerable<Order> GetAllOrder();

    User GetUser(User user);

    Toy GetToy(string id);

    Order GetOrder(string id);
  }
}
