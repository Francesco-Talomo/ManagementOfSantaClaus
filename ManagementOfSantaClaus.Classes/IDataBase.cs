using System.Collections.Generic;

namespace ManagementOfSantaClaus.Classes
{
  public interface IDataBase
  {
    User GetUser(User user);

    Toy GetToy(string id);

    Order GetOrder(string id);

    IEnumerable<Order> GetAllOrders();

    IEnumerable<Toy> GetAllToys();

    bool UpdateOrder(Order order);

    bool UpdateToy(Toy toy);
  }
}
