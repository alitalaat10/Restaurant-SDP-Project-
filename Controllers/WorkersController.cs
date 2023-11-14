using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Data;
using design_pattern.Models.Branches;
using design_pattern.Models.Workers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace design_pattern.Controllers
{
    [Route("[controller]/{BranchName}")]
    public class WorkersController : Controller
    {
        private readonly ILogger<WorkersController> _logger;
        private readonly AppDbContext db;
        public WorkersController(ILogger<WorkersController> logger, AppDbContext context)
        {
            _logger = logger;
            db = context;
        }

        private Manager manager;
        private void CreateManager(string BranchName)
        {
            ViewBag.BranchName = BranchName;
            manager = db.Managers.Where(x => x.BranchName == BranchName).FirstOrDefault();
            if (manager == null)
            {
                manager = new Manager() { BranchName = BranchName, salary = 1000, Type = WorkerType.Manager, workerName = "Manager" };
                db.Managers.Add(manager);
                db.SaveChanges();
            }
            manager.SetConnection(db);
        }

        [HttpGet("ViewWorkers")]
        public IActionResult ViewWorkers(string BranchName)
        {
            ViewBag.BranchName = BranchName;
            List<Worker> workers = db.Workers.Where(x => x.BranchName == BranchName).ToList();
            return View(workers);
        }

        [HttpGet("AddWorker")]
        public IActionResult AddWorker(string BranchName)
        {
            ViewBag.BranchName = BranchName;
            return View();
        }


        [HttpPost("AddWorker")]
        public IActionResult AddWorker(string workerName, int salary, WorkerType workerType, string BranchName)
        {
            CreateManager(BranchName);
            if (!ModelState.IsValid) return View();
            manager.addnewWorker(workerType, workerName, salary);
            db.SaveChanges();
            return RedirectToAction("ViewWorkers", new { BranchName = BranchName });
        }

        [HttpGet]
        [Route("{id}/Delete")]
        public IActionResult DeleteWorker(int id, string BranchName)
        {
            var worker = db.Workers.Where(x => x.Id == id).FirstOrDefault();
            if (worker == null) return NotFound();
            db.Workers.Remove(worker);
            db.SaveChanges();
            return RedirectToAction("ViewWorkers", new { BranchName = BranchName });
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}