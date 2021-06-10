using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pierres.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Pierres.Controllers
{
  [Authorize]
  public class FlavorsController : Controller 
  {
    private readonly PierresContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public FlavorsController(UserManager<ApplicationUser> userManager, PierresContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      var userFlavors = _db.Flavors.ToList();
      return View(_db.Flavors.ToList());
    }

    public ActionResult Create()
    {
      return View();
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
      .ThenInclude(join => join.Treat)
      .FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    public ActionResult Edit(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}