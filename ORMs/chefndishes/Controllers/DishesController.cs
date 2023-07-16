#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chefndishes.Models;

public class DishesController : Controller
{
    private readonly ILogger<DishesController> _logger;

    private MyContext _db;

    public DishesController(ILogger<DishesController> logger, MyContext context)
    {
        _logger = logger;
        _db = context;
    }

    [HttpGet("/dishes")]
    public IActionResult Dishes()
    {
        List<Dish> AllDishes = _db.Dishes.Include(dish => dish.Creator).ToList();
        return View("Dishes", AllDishes);
    }

    [HttpGet("/dishes/new")]
    public IActionResult NewDish()
    {
        ViewBag.allChefs = _db.Chefs.ToList();
        return View();
    }

    [HttpPost("/dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(!ModelState.IsValid)
        {
            ViewBag.allChefs = _db.Chefs.ToList();
            return View("NewDish");
        } else {
            _db.Dishes.Add(newDish);
            _db.SaveChanges();
            return RedirectToAction("Dishes");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
