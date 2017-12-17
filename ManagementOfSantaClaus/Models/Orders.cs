using ManagementOfSantaClaus.Classes;
using System.Collections.Generic;

namespace ManagementOfSantaClaus.Models
{
  public class Orders
  {
    public List<Classes.Order> EntityList { get; set; }

    public List<Toy> ToyList { get; set; }

    public decimal TotCost { get; set; }
  }
}