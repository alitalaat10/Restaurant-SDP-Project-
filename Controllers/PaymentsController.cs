using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Data;
using design_pattern.Models.Meal;
using design_pattern.Models.Payments;
using design_pattern.Models.Tables;
using design_pattern.Models.Workers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace design_pattern.Controllers
{
    [Route("[controller]/{BranchName}")]
    public class PaymentsController : Controller
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly AppDbContext db;
        private Cachier cachier;
        public PaymentsController(ILogger<PaymentsController> logger, AppDbContext context)
        {
            _logger = logger;
            db = context;
        }
        private void CreateCachier(string BranchName)
        {
            ViewBag.BranchName = BranchName;
            cachier = db.Cachiers.Where(x => x.BranchName == BranchName).FirstOrDefault();
            if (cachier == null)
            {
                cachier = new Cachier(){BranchName=BranchName, salary=1000, Type=WorkerType.Cachier, workerName="Cachier"};
                db.Cachiers.Add(cachier);
                db.SaveChanges();
            }
            cachier.SetConnection(db);
        }
        [HttpGet]
        public IActionResult Index(string BranchName)
        {
            ViewBag.BranchName = BranchName;
            return View(db.Payments.Include(x=>x.Order.Reservation.Table).Where(x=>x.Order.Reservation.Table.BranchName == BranchName).ToList());
        }
        [Route("{resId}/checkOut")]
        public IActionResult CheckOut(int resId, string BranchName)
        {
            CreateCachier(BranchName);
            ViewBag.Res = resId;
            // Reservation res = db.Reservations.Where(x => x.Id == id && x.Status == ReservStatus.OrderTaken).FirstOrDefault();
            // Order o = db.Orders.Where(x => x.ReservationId == id && x.Status == OrderStatus.Finished).FirstOrDefault();
            // if (res == null || o == null) return NotFound();
            // ViewBag.Order = o; ViewBag.Res = res;
            return View();
        }
        [Route("{resId}/checkOut/Cash")]
        [HttpGet]
        public IActionResult CashPay(int resId, string BranchName)
        {
            ViewBag.BranchName = BranchName;
            Reservation res = db.Reservations.Where(x => x.Id == resId && x.Status == ReservStatus.OrderTaken).FirstOrDefault();
            Order o = db.Orders.Include(x => x.MealItems).Where(x => x.ReservationId == resId && x.Status == OrderStatus.Finished).FirstOrDefault();
            if (res == null || o == null) return NotFound();
            ViewBag.Order = o; ViewBag.Res = res;
            return View();
        }
        [Route("{resId}/checkOut/Cash/Confirm")]
        [HttpGet]
        public IActionResult CashPayConfirm(int resId, string BranchName)
        {
            CreateCachier(BranchName);
            Reservation res = db.Reservations.Where(x => x.Id == resId && x.Status == ReservStatus.OrderTaken).FirstOrDefault();
            Order o = db.Orders.Include(x => x.MealItems).Where(x => x.ReservationId == resId && x.Status == OrderStatus.Finished).FirstOrDefault();
            if (res == null || o == null) return NotFound();
            res.Status = ReservStatus.CheckedOut;
            PaymentRecord p = new PaymentRecord(){Name=res.CustomerName, Amount=o.TotalPrice, Order=o};
            db.Payments.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Reservation", new { BranchName = BranchName, CheckOut = true });
        }
        [Route("{resId}/checkOut/Check")]
        [HttpGet]
        public IActionResult CheckPay(int resId, string BranchName)
        {
            ViewBag.BranchName = BranchName;
            Reservation res = db.Reservations.Where(x => x.Id == resId && x.Status == ReservStatus.OrderTaken).FirstOrDefault();
            Order o = db.Orders.Include(x => x.MealItems).Where(x => x.ReservationId == resId && x.Status == OrderStatus.Finished).FirstOrDefault();
            if (res == null || o == null) return NotFound();
            ViewBag.Order = o; ViewBag.Res = res;
            return View();
        }
        [Route("{resId}/checkOut/Check")]
        [HttpPost]
        public IActionResult CheckPay(int resId, string BranchName, DateTime dateOfExpire, string customerName)
        {
            CreateCachier(BranchName);
            Reservation res = db.Reservations.Where(x => x.Id == resId && x.Status == ReservStatus.OrderTaken).FirstOrDefault();
            Order o = db.Orders.Include(x => x.MealItems).Where(x => x.ReservationId == resId && x.Status == OrderStatus.Finished).FirstOrDefault();
            if (res == null || o == null) return NotFound();
            res.Status = ReservStatus.CheckedOut;
            PaymentRecord p = new PaymentRecord(){Name=customerName, Amount=o.TotalPrice, DateOfExpire=dateOfExpire, Order=o, Type=PaymentType.Check};
            db.Payments.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Reservation", new { BranchName = BranchName, CheckOut = true });
        }
        [Route("{resId}/checkOut/Credit")]
        [HttpGet]
        public IActionResult CreditPay(int resId, string BranchName)
        {
            // CreateCachier(BranchName);
            ViewBag.BranchName = BranchName;
            Reservation res = db.Reservations.Where(x => x.Id == resId && x.Status == ReservStatus.OrderTaken).FirstOrDefault();
            Order o = db.Orders.Include(x => x.MealItems).Where(x => x.ReservationId == resId && x.Status == OrderStatus.Finished).FirstOrDefault();
            if (res == null || o == null) return NotFound();
            ViewBag.Order = o; ViewBag.Res = res;
            return View();
        }
        [Route("{resId}/checkOut/Credit")]
        [HttpPost]
        public IActionResult CreditPay(int resId, string BranchName, DateTime dateOfExpire, string customerName, string cvv, string cardNumber)
        {
            CreateCachier(BranchName);
            Reservation res = db.Reservations.Where(x => x.Id == resId && x.Status == ReservStatus.OrderTaken).FirstOrDefault();
            Order o = db.Orders.Include(x => x.MealItems).Where(x => x.ReservationId == resId && x.Status == OrderStatus.Finished).FirstOrDefault();
            if (res == null || o == null) return NotFound();
            res.Status = ReservStatus.CheckedOut;
            PaymentRecord p = new PaymentRecord(){Name=customerName, Amount=o.TotalPrice, DateOfExpire=dateOfExpire, CVV=cvv, CreditCard=cardNumber, Order=o, Type=PaymentType.Credit};
            db.Payments.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Reservation", new { BranchName = BranchName, CheckOut = true });
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}