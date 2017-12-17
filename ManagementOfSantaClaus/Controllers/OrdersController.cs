using ManagementOfSantaClaus.Classes;
using ManagementOfSantaClaus.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ManagementOfSantaClaus.Controllers
{
  public class OrdersController : Controller
  {
    public ActionResult Index()
    {
      if (Session["IsAdmin"] != null)
      {
        Classes.MongoDB db = new Classes.MongoDB();
        var orders = db.GetAllOrders();
        var toys = db.GetAllToys();
        Orders model = new Orders();
        model.EntityList = orders.ToList();
        model.ToyList = toys.ToList();
        return View(model);
      }
      else
      {
        return RedirectToAction("../Users/Login");
      }
    }

    public ActionResult Details(string id)
    {
      if (Session["IsAdmin"] != null)
      {
        Classes.MongoDB db = new Classes.MongoDB();
        var order = db.GetOrder(id);
        var toys = db.GetAllToys();
        Models.Order model = new Models.Order();
        model.Id = order.Id;
        model.Kid = order.Kid;
        model.Status = order.Status;
        model.Date = order.Date;
        model.Toys = order.Toys;
        model.ToyList = toys.ToList();
        return View(model);
      }
      else
      {
        return RedirectToAction("../Users/Login");
      }
    }

    public ActionResult Edit(string id)
    {
      if (Session["IsAdmin"] != null)
      {
        Classes.MongoDB db = new Classes.MongoDB();
        ViewBag.StatusTypes = new StatusTypes();
        var order = db.GetOrder(id);
        Classes.Order model = new Classes.Order();
        model.Id = order.Id;
        model.Kid = order.Kid;
        model.Status = order.Status;
        model.Date = order.Date;
        model.Toys = order.Toys;
        return View(model);
      }
      else
      {
        return RedirectToAction("../Users/Login");
      }
    }

    public ActionResult Save(string id, StatusType statusType)
    {
      if (Session["IsAdmin"] != null || statusType.Equals(StatusType.Done))
      {
        Classes.MongoDB db = new Classes.MongoDB();
        bool result;
        var order = db.GetOrder(id);
        var toys = db.GetAllToys().ToList();
        bool allToysIsPresent = ControlToy(order, toys);
        if (allToysIsPresent == true || statusType.Equals(StatusType.InProgress))
        {
          switch (order.Status)
          {
            case StatusType.InProgress:
              if (!statusType.Equals(StatusType.InProgress))
              {
                RemoveToy(db, order, toys);
                result = db.UpdateOrder(new Classes.Order
                {
                  Id = id,
                  Status = statusType
                });
              }
              break;
            case StatusType.Ready:
              if (statusType.Equals(StatusType.InProgress))
              {
                AddToy(db, order, toys);
                result = db.UpdateOrder(new Classes.Order
                {
                  Id = id,
                  Status = statusType
                });
              }
              else if (statusType.Equals(StatusType.Done))
              {
                if (!statusType.Equals(StatusType.InProgress))
                {
                  RemoveToy(db, order, toys);
                  result = db.UpdateOrder(new Classes.Order
                  {
                    Id = id,
                    Status = statusType
                  });
                }
              }
              break;
          }
          return RedirectToAction("Index");
        }
        else
        {
          return RedirectToAction("../Toys/MissingToy");
        }
      }
      else
      {
        return RedirectToAction("../Users/Login");
      }
    }

    bool ControlToy(Classes.Order order, List<Toy> toys)
    {
      foreach (var toyOrder in order.Toys)
      {
        foreach (var toy in toys)
        {
          if (toy.Name == toyOrder.Name)
          {
            if (toy.Amount == 0)
            {
              return false;
            }
          }
        }
      }
      return true;
    }

    void RemoveToy(Classes.MongoDB db, Classes.Order order, List<Toy> toys)
    {
      bool result;
      foreach (var toyOrder in order.Toys)
      {
        foreach (var toy in toys)
        {
          if (toy.Name.Equals(toyOrder.Name))
          {
            result = db.UpdateToy(new Toy
            {
              Name = toy.Name,
              Amount = toy.Amount - 1
            });
          }
        }
      }
    }

    void AddToy(Classes.MongoDB db, Classes.Order order, List<Toy> toys)
    {
      bool result;
      foreach (var toyOrder in order.Toys)
      {
        foreach (var toy in toys)
        {
          if (toy.Name.Equals(toyOrder.Name))
          {
            result = db.UpdateToy(new Toy
            {
              Name = toy.Name,
              Amount = toy.Amount + 1
            });
          }
        }
      }
    }
  }
}
