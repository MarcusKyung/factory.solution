using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Linq;
using System.Collections.Generic;

namespace Factory.Controllers
{
    public class HomeController : Controller
    {
      private readonly FactoryContext _db;

      public HomeController(FactoryContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        Engineer[] engineers = _db.Engineers.OrderBy(engineers => engineers.EngineerName).ToArray();
        Machine[] machines = _db.Machines.OrderBy(machines => machines.MachineName).ToArray();
        Dictionary<string,object[]> model = new Dictionary<string, object[]>();
        model.Add("engineers", engineers);
        model.Add("machines", machines);
        return View(model);
      }
    }
}