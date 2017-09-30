using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendingMachines.Models;

namespace VendingMachines.Controllers {
  public class MachinesController : Controller {

    private static Machine m;

    static MachinesController() {
      m = new Machine();
      m.AcceptableCoinsText = "5, 10, 20, 50";

      var p1 = new Product { Id = 1, Name = "Water", Price = 10 };
      var p2 = new Product { Id = 2, Name = "Water", Price = 20 };
      var p3 = new Product { Id = 3, Name = "Water", Price = 30 };
      var p4 = new Product { Id = 4, Name = "Water", Price = 40 };
      var p5 = new Product { Id = 5, Name = "Water", Price = 50 };

      var s1 = new Slot { Quantity = 5, Product = p1 };

      m.Slots.Add(s1);
    }

    public IActionResult Index() {
      return View(m);
    }

    [HttpPost]
    public IActionResult AddCoin(decimal amount) {
      try {
        m.InsertCoin(amount);
      }
      catch (Exception ex) {
        TempData["Error"] = ex.Message;
      }

      //return View("Index", m);
      return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult ChangeStatus(bool status) {
      if (status == true)
        m.TurnOn();
      else
        m.TurnOff();

      return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Cancel() {
      m.CancelBuying();
      return RedirectToAction("Index");
    }
  }
}