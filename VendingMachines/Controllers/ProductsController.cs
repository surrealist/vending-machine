using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendingMachines.Models;

namespace VendingMachines.Controllers {
  public class ProductsController : Controller {

    private static List<Product> products;

    static ProductsController() {
      products = new List<Product>();
    }

    public IActionResult Index() {
      return View(products);
    }

    public IActionResult Create() {
      return View();
    }

    public IActionResult CheckDuplicateName(string name) {
      if (products.Any(p => p.Name == name)) {
        return Json("Name is duplicate.");
      }

      return Json(true);
    }

    [HttpPost]
    public IActionResult Create(Product product) {

      ModelState.Remove("CreatedBy");

      //if (products.Any(p => p.Name == product.Name)) {
      //  ModelState.AddModelError(nameof(product.Name), "ชื่อสินค้านี้มีใช้แล้ว");
      //}

      if (product.Price % 5 != 0) {
        ModelState.AddModelError("Price", "ราคาไม่ถูกต้อง");
      }

      if (!ModelState.IsValid) {
        return View(product);
      }

      product.CreatedBy = "user1";
      products.Add(product);
      return RedirectToAction("Index");
    }

  }
}