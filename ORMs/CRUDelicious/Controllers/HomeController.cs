using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        // When our HomeController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.OrderByDescending(d => d.DishId).ToList();
        return View("Index", AllDishes);
    }

    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        return View("CreateDish");
    }

    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish Dishes)
    {
        if(ModelState.IsValid)
        {
            _context.Add(Dishes);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            return View("CreateDish");
        }
    }

    [HttpGet("dishes/{dishId}")]
    public IActionResult OneDish(int dishId)
    {
        Dish? dishById = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if(dishById == null)
        {
            return RedirectToAction("Index");
        }
        return View("OneDish", dishById);
    }

    [HttpGet("dishes/{dishId}/edit")]
    public IActionResult Edit(int dishId)
    {
        Dish? editOne = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);
        return View(editOne);
    }

    [HttpPost("dishes/{dishId}/update")]
    public IActionResult UpdateOne(Dish updateOne, int dishId)
    {
        if(!ModelState.IsValid)
        {
            return Edit(dishId);
        }
        Dish? updateDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);

        if(updateDish ==null)
        {
            return RedirectToAction("Index");
        }
        updateDish.Chef = updateOne.Chef;
        updateDish.Name = updateOne.Name;
        updateDish.Calories = updateOne.Calories;
        updateDish.Tastiness = updateOne.Tastiness;
        updateDish.Description = updateOne.Description;
        updateDish.UpdatedAt = DateTime.Now;
        _context.Dishes.Update(updateDish);
        _context.SaveChanges();
        return RedirectToAction("Index", updateDish);
    }

    [HttpPost("dishes/{dishId}/destroy")]
    public IActionResult Destroy(int dishId)
    {
        Dish? removeDish = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);
        if(removeDish != null)
        {
            _context.Dishes.Remove(removeDish);
            _context.SaveChanges();
        }
        return RedirectToAction("Index", removeDish);
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
