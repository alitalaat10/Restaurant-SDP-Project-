using Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Data;
using design_pattern.Models.Menu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using design_pattern.Models.Branches;
using design_pattern.Models.Workers;

namespace design_pattern.Controllers
{
    [Route("[controller]/{BranchName}")]
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;
        private readonly AppDbContext _context;
        public MenuController(ILogger<MenuController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        private Manager manager;
        private void CreateManager(string BranchName)
        {
            ViewBag.BranchName = BranchName;
            manager = _context.Managers.Where(x => x.BranchName == BranchName).FirstOrDefault();
            if (manager == null)
            {
                manager = new Manager() { BranchName = BranchName, salary = 1000, Type = WorkerType.Manager, workerName = "Manager" };
                _context.Managers.Add(manager);
                _context.SaveChanges();
            }
            manager.SetConnection(_context);
        }
        [HttpGet("MenuSections")]
        public IActionResult MenuSections(string BranchName)
        {
            try
            {
                List<MenuSection> sections = _context.MenuSections.Where(x => x.BranchName == BranchName).Include(x => x.Items).ToList();
                ViewBag.BranchName = BranchName;
                ViewBag.sections = sections;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
        [HttpGet("AddMenuSection")]
        public IActionResult AddMenuSection(string BranchName)
        {
            ViewBag.BranchName = BranchName;
            return View();
        }
        [HttpPost("AddMenuSection")]
        public IActionResult AddMenuSection(string BranchName, string name, string desc, List<MenuItem> items)
        {
            CreateManager(BranchName);
            MenuSection sec = new MenuSection(name, desc);
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                sec.Add(item);
            }
            manager.AddSection(sec);
            _context.SaveChanges();
            return RedirectToAction("MenuSections", new { BranchName = BranchName });
        }
        [Route("{id}/Edit")]
        [HttpGet]
        public IActionResult EditMenuSection(int id, string BranchName)
        {
            ViewBag.BranchName = BranchName;
            MenuSection sec = _context.MenuSections.Include(b => b.Items).Where(b => b.Id == id && b.BranchName == BranchName).FirstOrDefault();
            if (sec == null) return NotFound();
            ViewBag.sectionId = id;
            return View(sec);
        }
        [Route("{id}/Edit")]
        [HttpPost]
        public IActionResult EditMenuSection(int id, string name, string desc, List<MenuItem> items, string BranchName)
        {
            CreateManager(BranchName);
            MenuSection sec = _context.MenuSections.Include(x => x.Items).Where(b => b.Id == id && b.BranchName == BranchName).FirstOrDefault();
            if (!manager.EditMenuSection(id, new MenuSection(name, desc), items))
                return NotFound();
            _context.SaveChanges();
            return RedirectToAction("MenuSections", new { BranchName = BranchName });
        }
        [Route("{id}/Delete")]
        [HttpGet]
        public IActionResult DeleteMenuSection(int id, string BranchName)
        {
            ViewBag.BranchName = BranchName;
            MenuSection sec = _context.MenuSections.Where(b => b.Id == id && b.BranchName == BranchName).FirstOrDefault();
            if (sec == null) return NotFound();
            _context.MenuSections.Remove(sec);
            _context.SaveChanges();
            return RedirectToAction("MenuSections", new { BranchName = BranchName });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}