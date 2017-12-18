using ManagementOfSantaClaus.Classes;
using System.Collections.Generic;

namespace ManagementOfSantaClaus.Models
{
  public class Orders
  {
    public List<Classes.Order> OrdersList { get; set; }

    public List<Toy> ToysList { get; set; }

    public decimal TotCost { get; set; }

    public List<Toy> MissingToysList { get; set; }
  }
}