using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using design_pattern.Models;
using design_pattern.Data;
using design_pattern.Models.Branches;
using System.Security.Claims;

namespace design_pattern.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;
    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        bool isAuth = Convert.ToBoolean(HttpContext.Session.GetInt32("isAuth"));
        ViewBag.isAuth = isAuth;
        _logger.LogInformation($"{isAuth}");
        List<Branch> branches = _context.Branches.ToList();
        Console.WriteLine(HttpContext.User.FindFirstValue("Id"));
        return View(branches);
    }

    [HttpGet("Branch/{BranchName}")]
    public IActionResult Branch(string BranchName, string Worker)
    {
        bool isAuth = Convert.ToBoolean(HttpContext.Session.GetInt32("isAuth"));
        ViewBag.isAuth = isAuth;
        _logger.LogInformation($"{isAuth}");
        ViewBag.Worker = Worker;
        Branch branch = _context.Branches.Where(x=>x.Name == BranchName).FirstOrDefault();
        if(branch == null) return NotFound();
        return View(branch);
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
