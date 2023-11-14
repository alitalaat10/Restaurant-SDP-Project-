using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Data;
using design_pattern.Models.Workers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using design_pattern.Models.Meal;
using design_pattern.Models.Menu;
using design_pattern.Models.Tables;

namespace design_pattern.Controllers
{
    [Route("[controller]/{BranchName}")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly AppDbContext db;
        private Waiter waiter;
        private Chef chef;
        public OrderController(ILogger<OrderController> logger, AppDbContext context)
        {
            _logger = logger;
            db = context;
        }

        private void FillViewBag(string BranchName)
        {
            ViewBag.BranchName = BranchName;
        }

        private void CreateWaiter(string BranchName)
        {
            waiter = db.Waiters.Where(x => x.BranchName == BranchName).FirstOrDefault();
            if (waiter == null)
            {
                waiter = new Waiter(){BranchName=BranchName, salary=1000, Type=WorkerType.Waiter, workerName="Waiter"};
                db.Waiters.Add(waiter);
                db.SaveChanges();
            }
            waiter.SetConnection(db);
        }
        private void CreateChef(string BranchName)
        {
            chef = db.Chefs.Where(x => x.BranchName == BranchName).FirstOrDefault();
            if (chef == null)
            {
                chef = new Chef(){BranchName=BranchName, salary=1000, Type=WorkerType.Chef, workerName="Chef"};
                db.Chefs.Add(chef);
                db.SaveChanges();
            }
            chef.SetConnection(db);
        }
        private void InitializeChef(string BranchName)
        {
            FillViewBag(BranchName);
            CreateChef(BranchName);
        }
        private void InitializeWaiter(string BranchName)
        {
            FillViewBag(BranchName);
            CreateWaiter(BranchName);
        }
        private void Initialize(string BranchName)
        {
            FillViewBag(BranchName);
            CreateChef(BranchName);
            CreateWaiter(BranchName);
        }

        [HttpGet]
        public IActionResult Index(string BranchName, bool Unfinished)
        {
            FillViewBag(BranchName);
            ViewBag.Unfinished = Unfinished;
            var orders = db.Orders.Include(x => x.MealItems)
                .Include(x => x.Reservation.Table)
                .Where(x => x.Reservation.Table.BranchName == BranchName &&
                    x.Reservation.Status == ReservStatus.OrderTaken
                );
            if (Unfinished) orders = orders.Where(x => x.Status == OrderStatus.Waiting);
            return View(orders.ToList());
        }
        [Route("{TableId}/{resId}/AddOrder")]
        [HttpGet]
        public IActionResult AddOrder(string BranchName, int TableId, int resId)
        {
            FillViewBag(BranchName);
            Reservation res = db.Reservations.Include(x => x.Table).Where(x => x.Id == resId && x.Table.Number == TableId && x.Status == ReservStatus.CheckedIn).FirstOrDefault();
            if (res == null) return NotFound();
            ViewBag.Seats = res.Table.Seats;
            ViewBag.TableId = TableId;
            ViewBag.resId = resId;
            ViewBag.MenuItems = db.MenuItems.Include(x => x.MenuSection).Where(x => x.MenuSection.BranchName == BranchName).ToList();
            return View();
        }
        [Route("{TableId}/{resId}/AddOrder")]
        [HttpPost]
        public IActionResult AddOrder(string BranchName, int TableId, int resId, List<List<int>> Meals)
        {
            InitializeWaiter(BranchName);
            waiter.CreateNewOrder(resId, TableId, Meals);
            db.SaveChanges();
            return RedirectToAction("Index", "Reservation", new { BranchName = BranchName, InSeats = true });
        }
        // [Route("{id}/Edit")]
        // public IActionResult EditOrder(string BranchName, int id)
        // {
        //     ViewBag.BranchName = BranchName;

        //     return View();
        // }
        // [Route("{id}/Edit")]
        // public IActionResult EditOrder(string BranchName, int id, string data)
        // {
        //     ViewBag.BranchName = BranchName;

        //     return RedirectToAction("Index", new { BranchName = BranchName });
        // }
        [Route("{id}/FinishOrder")]
        public IActionResult FinishOrder(string BranchName, int id)
        {
            ViewBag.BranchName = BranchName;
            Order o = db.Orders.Where(x => x.Id == id && x.Status == OrderStatus.Waiting).FirstOrDefault();
            if (o == null) return NotFound();
            o.Status = OrderStatus.Finished;
            db.SaveChanges();
            return RedirectToAction("Index", new { BranchName = BranchName, Unfinished = true });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}