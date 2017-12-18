using ManagementOfSantaClaus.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementOfSantaClaus.Models
{
  public class Order
  {
    public string Id { get; set; }

    public string Kid { get; set; }

    public StatusType Status { get; set; }

    public List<Toy> Toys { get; set; }

    public DateTime Date { get; set; }

    public List<Toy> ToyList { get; set; }

    public decimal TotCost { get; set; }

    public bool EditToys { get;  set; }

    public List<Toy> MissingToysList { get; set; }
  }
}