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
    }
}