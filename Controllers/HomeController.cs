using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pirate.Models;
using Microsoft.EntityFrameworkCore;

namespace Pirate.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context {get;set;}
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<PirateMember> pirate = _context.Crews.ToList();
            // List<PirateMember> pirate = _context.Crews.OrderBy(p => p.PirateRole).ToList(); //ascending order
            // List<PirateMember> pirate = _context.Crews.OrderByDescending(p => p.PirateRole).ToList(); //descending order
            return View(pirate);
        }

        [HttpGet("add")]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost("create")]
        public IActionResult Create(PirateMember newPirate)
        {
            if(ModelState.IsValid)
            {
                _context.Crews.Add(newPirate);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Add");
            }
        }

        [HttpGet("{CrewID}")]
        public IActionResult Show(int CrewID)
        {
            PirateMember show = _context.Crews.FirstOrDefault(p => p.PirateId == CrewID);
            return View(show);
        }

        [HttpGet("edit/{CrewID}")]
        public IActionResult Edit(int CrewID)
        {
            PirateMember edit = _context.Crews.FirstOrDefault(p => p.PirateId == CrewID);
            return View(edit);
        }

        [HttpPost("update/{CrewID}")]
        public IActionResult Update(int CrewID, PirateMember update)
        {
            PirateMember get = _context.Crews.FirstOrDefault(p =>p.PirateId == CrewID);
            if(ModelState.IsValid)
            {
                get.Name = update.Name;
                get.Age = update.Age;
                get.PirateRole = update.PirateRole;
                get.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return Redirect($"/{CrewID}");
            }
            else
            {
                update.PirateId = CrewID;
                return View("Edit", update);
            }
        }

        [HttpGet("delete/{CrewID}")]
        public IActionResult Delete(int CrewID)
        {
            PirateMember get = _context.Crews.FirstOrDefault(p => p.PirateId ==CrewID);
            _context.Crews.Remove(get);
            _context.SaveChanges();
            return Redirect("/");
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
