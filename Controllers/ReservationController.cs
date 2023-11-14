using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Classes.NotificationSystem;
using design_pattern.Data;
using design_pattern.Models.Meal;
using design_pattern.Models.Tables;
using design_pattern.Models.Workers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace design_pattern.Controllers
{
    [Route("[controller]/{BranchName}")]
    public class ReservationController : Controller
    {
        private readonly ILogger<ReservationController> _logger;

        private readonly AppDbContext db;
        private Receptionist receptionist;
        public ReservationController(ILogger<ReservationController> logger, AppDbContext context)
        {
            _logger = logger;
            db = context;
        }
        private void CreateReceptionist(string BranchName, int TableId)
        {
            ViewBag.BranchName = BranchName;
            if (TableId > 0)
                ViewBag.TableId = TableId;
            receptionist = db.Receptionists.Where(x => x.BranchName == BranchName).FirstOrDefault();
            if (receptionist == null)
            {
                receptionist = new Receptionist(){BranchName=BranchName, salary=1000, Type=WorkerType.Receptionist, workerName="Receptionist"};
                db.Receptionists.Add(receptionist);
                db.SaveChanges();
            }
            receptionist.SetConnection(db);
        }

        [HttpGet]
        public IActionResult Index(string BranchName, int TableId, bool InSeats, bool OrderTaken, bool CheckOut, bool Waiting)
        {
            CreateReceptionist(BranchName, TableId);
            var res = db.Reservations.Include(x => x.Table).Include(x => x.Order).Where(x => x.Table.BranchName == BranchName);
            if (TableId > 0) res = res.Where(x => x.Table.Number == TableId && x.Status == ReservStatus.Waiting);
            else
            {
                if (CheckOut) res = res.Where(x => x.Status == ReservStatus.OrderTaken && x.Order != null && x.Order.Status == OrderStatus.Finished);
                else if (OrderTaken) res = res.Where(x => x.Status == ReservStatus.OrderTaken);
                else if (InSeats) res = res.Where(x => x.Status == ReservStatus.CheckedIn);
                else if (Waiting) res = res.Where(x => x.Status == ReservStatus.Waiting);
            }
            return View(res.ToList());
        }
        [Route("addReservation")]
        [HttpGet]
        public IActionResult ReserveTable(string BranchName, int TableId)
        {
            CreateReceptionist(BranchName, TableId);
            ViewBag.BranchName = BranchName;
            Table table = db.Tables.Where(x => x.Number == TableId && x.BranchName == BranchName).FirstOrDefault();
            if (table == null) return NotFound();
            return View(table);
        }
        [Route("addReservation")]
        [HttpPost]
        public IActionResult ReserveTable(int TableId, DateTime ReservationDate, string CustomerName, string BranchName, string CustomerEmail = "", string CustomerPhone = "")
        {
            CreateReceptionist(BranchName, TableId);
            Table table = db.Tables.Where(x => x.Number == TableId && x.BranchName == BranchName).FirstOrDefault();
            if (table == null) return NotFound();
            receptionist.CreateReservation(table, ReservationDate, CustomerName, CustomerEmail, CustomerPhone);

            db.SaveChanges();
            return RedirectToAction("Index", "Table", new { BranchName = BranchName, TableId = TableId });
        }
        [Route("{id}/SendReminder")]
        public async Task<IActionResult> SendReminder(int id, string BranchName)
        {
            NotificationFacade notif = new NotificationFacade();
            Reservation res = db.Reservations.Include(x=>x.Table).Where(x=>x.Id == id && (x.CustomerName != string.Empty || x.CustomerPhone != string.Empty)).FirstOrDefault();
            if(res != null){
                if (res.CustomerEmail != string.Empty && res.CustomerEmail != null)
                {
                    await notif.SendReservationReminder("mail", res.CustomerEmail, $"We remind you that you have reserved a table of {res.Table.Seats} Seats At {res.Date.ToString()}");
                }
                if (res.CustomerPhone != string.Empty && res.CustomerPhone != null)
                {
                    await notif.SendReservationReminder("sms", "+20" + res.CustomerPhone, $"We remind you that you have reserved a table of {res.Table.Seats} Seats At {res.Date.ToString()}");
                }
            }
            return RedirectToAction("index", new { BranchName = BranchName, Waiting=true});
        }

        [Route("{id}/cancelReservation")]
        public async Task<IActionResult> CancelReservation(int id, string BranchName, int TableId)
        {
            CreateReceptionist(BranchName, TableId);
            Reservation res = receptionist.CancelReservation(id);
            if (res == null) return NotFound();
            NotificationFacade notif = new NotificationFacade();
            if (res.CustomerEmail != null && res.CustomerEmail != string.Empty)
            {
                await notif.SendCancelReservationNotif("mail", res.CustomerEmail);
            }
            if (res.CustomerPhone != null && res.CustomerPhone != string.Empty)
            {
                await notif.SendCancelReservationNotif("sms", "+20" + res.CustomerPhone);
            }
            db.SaveChanges();
            return RedirectToAction("Index", new { BranchName = BranchName, Waiting = true });
        }
        [Route("{id}/checkIn")]
        public IActionResult CheckIn(int id, string BranchName, int TableId)
        {
            CreateReceptionist(BranchName, TableId);
            Reservation res = receptionist.CheckInReservation(id);
            if (res == null) return NotFound();
            db.SaveChanges();
            return RedirectToAction("Index", new { BranchName = BranchName, Waiting=true });
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}