using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pierres.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using System;

namespace Pierres.Controllers
{
    public class TreatsController : Controller
    {
      private readonly PierresContext _db;
      private readonly UserManager<ApplicationUser> _userManager;

      public TreatsController(UserManager<ApplicationUser> userManager, PierresContext db)
      {
        _userManager = userManager;
        _db =db;
      }

      public ActionResult Index()
      {
        return ViewModels(_db.Treats.OrderBy(treat => treat.Rating).ToList());
      }

      public ActionResult Create()
      {
        ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
        return ViewModels();
      }

      [HttpPost]
      public ActionResult Create(Treat treat, int FlavorId)
      {
        _db.Treats.Add(treat);
        _db.SaveChanges();
        if (FlavorId != 0)
        {
          _db.FlavorTreat.Add(new FlavorTreat() {FlavorId = FlavorId, TreatId = treat.TreatId});
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      public ActionResult Details(int id)
      {
        var thisTreat = _db.Treats
        .Include(treat => treat.JoinEntities)
        .ThenInclude(join => join.Flavor)
        .FirstOrDefault(treat => treat.TreatId ==id);
        return ViewModels(thisTreat);
      }

      public ActionResult Edit(int id)
      {
        var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
        ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
        return ViewModels(thisTreat);
      }

      [HttpPost]
      public ActionResult Edit(Treat treat, int FlavorsId)
      {
        FlavorTreat joinTableEntry = null;
        try
        {
          joinTableEntry = _db.FlavorTreat.Where(entry => (entry.TreatId == treat.TreatId && entry.FlavorID == FlavorId)).Single();
        }
        catch (System.Exception)
        {
          Console.WriteLine("Doesnt exist in FlavorTreat entry in table");
        }

        if (FlavorsId != 0 && joinTableEntry == null)
        {
          _db.FlavorTreat.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = treat.TreatId});
        }
        _db.Entry(treat).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      public ActionResult AddFlavor(int id)
      {
        var thisFlavor = _db.Flavors.FirstOrDefault(treat => treat.TreatId == id);
        ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
        return View(thisRecipe);
      }

      [HttpPost]
      public ActionResult AddFlavor(Treat treat, int FlavorId)
      {
        if (FlavorId != 0)
        {
          _db.FlavorTreat.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = treat.TreatId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      
      public ActionResult Delete(int id)
      {
        var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
        return ViewModels(thisTreat);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfrimed(int id)
      {
        var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
        _db.Treats.Remove(thisTreat);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      [HttpPost]
      public ActionResult DeleteFlavor(int joinId)
      {
      var joinEntry = _db.FlavorTreat.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
      _db.FlavorTreat.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
      }
    }
}