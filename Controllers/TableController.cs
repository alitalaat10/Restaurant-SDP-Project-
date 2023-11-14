using design_pattern.Models.Tables;
using design_pattern.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using design_pattern.Classes.NotificationSystem;
using design_pattern.Models.Workers;

namespace design_pattern.Controllers
{
    [Route("[controller]/{BranchName}")]
    public class TableController : Controller
    {
        private readonly ILogger<TableController> _logger;
        private readonly AppDbContext _context;
        private Receptionist receptionist;
        public TableController(ILogger<TableController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        private void CreateReceptionist(string BranchName)
        {
            ViewBag.BranchName = BranchName;
            receptionist = _context.Receptionists.Where(x => x.BranchName == BranchName).FirstOrDefault();
            if (receptionist == null)
            {
                receptionist = new Receptionist(){BranchName=BranchName, salary=1000, Type=WorkerType.Receptionist, workerName="Receptionist"};
                _context.Receptionists.Add(receptionist);
                _context.SaveChanges();
            }
            receptionist.SetConnection(_context);
        }

        [HttpGet]
        public IActionResult Index(bool availableOnly, string BranchName, int Seats, string? pos, DateTime ReservationDate)
        {
            CreateReceptionist(BranchName);
            var tables = _context.Tables.Where(x => x.BranchName == BranchName);
            if (Seats > 0) tables = tables.Where(x => x.Seats == Seats);
            if (pos != null)
            {
                if (int.Parse(pos) == 0) tables = tables.Where(x => x.Position == PositionType.Indoor);
                else if (int.Parse(pos) == 1) tables = tables.Where(x => x.Position == PositionType.Outdoor);
                ViewBag.pos = int.Parse(pos);
            }
            if (availableOnly)
            {
                var date = ReservationDate > DateTime.Now ? ReservationDate : DateTime.Now;
                Console.WriteLine(date);
                tables = tables.Include(x => x.Reservations).Where(x => !x.Reservations.Any(b =>
                    (date > b.Date.AddHours(1) || b.Date <= date.AddHours(1)) && b.Status != ReservStatus.CheckedOut
                )); 
                ViewBag.ReservationDate = date.ToString("yyyy-MM-dd hh:mm:ss");
                Console.WriteLine(ViewBag.ReservationDate);
            }
            ViewBag.Seats = Seats;
            ViewBag.availableOnly = availableOnly;
            return View(tables.ToList());
        }

        [HttpGet("AddTable")]
        public IActionResult AddTable(string BranchName)
        {
            ViewBag.BranchName = BranchName;
            return View();
        }
        [HttpPost("AddTable")]
        public IActionResult AddTable(int Seats, PositionType Position, string BranchName)
        {
            CreateReceptionist(BranchName);
            Table table = new Table(Seats, Position > 0 ? PositionType.Outdoor : PositionType.Indoor);
            if (!ModelState.IsValid) return View(table);
            receptionist.AddTable(Seats, Position);
            _context.SaveChanges();
            return RedirectToAction("Index", new { BranchName = BranchName });
        }
        [Route("{id}/Edit")]
        [HttpGet]
        public IActionResult EditTable(int id, string BranchName)
        {
            ViewBag.BranchName = BranchName;
            Table table = _context.Tables.Where(x => x.Number == id && x.BranchName == BranchName).FirstOrDefault();
            if (table == null) return NotFound();
            return View(table);
        }
        [Route("{id}/Edit")]
        [HttpPost]
        public IActionResult EditTable(int id, int Seats, PositionType Position, string BranchName)
        {
            CreateReceptionist(BranchName);
            if (!receptionist.ModifyTable(id, Seats, Position))
                return NotFound();
            _context.SaveChanges();
            return RedirectToAction("Index", new { BranchName = BranchName });
        }
        [Route("{id}/Delete")]
        [HttpGet]
        public IActionResult DeleteTable(int id, string BranchName)
        {
            CreateReceptionist(BranchName);
            if (!receptionist.RemoveTable(id)) return NotFound();
            _context.SaveChanges();
            return RedirectToAction("Index", new { BranchName = BranchName });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}