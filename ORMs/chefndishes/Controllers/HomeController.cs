#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chefndishes.Models;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext _db;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _db = context;
    }

    [HttpGet("")]
    public IActionResult Chefs()
    {
        List<Chef> AllChefs = _db.Chefs.Include(chef => chef.AllDishes).ToList();
        return View("Chefs", AllChefs);
    }

    [HttpGet("chefs/new")]
    public IActionResult NewChef()
    {
        return View("NewChef");
    }

    [HttpPost("chefs/create")]
    public IActionResult CreateChef(Chef newChefs)
    {
        if(!ModelState.IsValid)
        {
            return View("NewChef");
        } 
            _db.Chefs.Add(newChefs);
            _db.SaveChanges();
            return RedirectToAction("Chefs", newChefs);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
