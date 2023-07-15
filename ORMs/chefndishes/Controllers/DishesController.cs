#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using chefndishes.Models;

namespace chefndishes.Controllers;

public class DishesController : Controller
{
    private readonly ILogger<DishesController> _logger;

    private MyContext _db;

    public DishesController(ILogger<DishesController> logger, MyContext context)
    {
        _logger = logger;
        _db = context;
    }

    public IActionResult Dishes()
    {
        return View();
    }

    public IActionResult NewDish()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
