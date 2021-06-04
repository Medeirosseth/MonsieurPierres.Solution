using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pierres.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pierres.Controllers
{
  public class FlavorsController : Controller 
  {
    private readonly PierresContext _db;

    public FlavorsController(PierresContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Flavor> model = _db.Flavors.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return ViewModels();
    }

    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisFlavor = _db.Flavors
      .Include(flavor => flavor.JoinEntities)
      .ThenInclude(join => join.Recipe)
      .FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }
  }
}