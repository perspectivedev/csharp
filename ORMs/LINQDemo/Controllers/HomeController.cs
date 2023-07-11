using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LINQDemo.Models;

namespace LINQDemo.Controllers;

public class HomeController : Controller
{
    public static Game[] AllGames = new Game[]
    {
        new Game {Title="Red Dead Redemption 2", Price=59.00, Genre="Western", Rating="M", Platform="PS4"},
        new Game {Title="Spiderman", Price=59.00, Genre="Superhero", Rating="T", Platform="Xbox"},
        new Game {Title="Assassin's Creed: Valhalla", Price=39.00, Genre="Action", Rating="M", Platform="Xbox"},
        new Game {Title="Madden22", Price=49.00, Genre="Sport", Rating="E", Platform="All"},
        new Game {Title="Mortal Combat 12", Price=59.00, Genre="Action", Rating="M", Platform="PS5/Xbox"},
        new Game {Title="Apex Legends", Price=59.00, Genre="Action", Rating="M", Platform="All"},
        new Game {Title="Star Wars: Survivor", Price=89.00, Genre="Adventure", Rating="E", Platform="PS5/Xbox"},
        new Game {Title="Witcher", Price=29.00, Genre="RPG", Rating="M", Platform="Xbox/PS5"},
        new Game {Title="Call of Duty: ColdWar", Price=20.00, Genre="Action", Rating="M", Platform="Xbox/PS5"},
        new Game {Title="Mario Cart", Price=19.00, Genre="Action", Rating="E", Platform="Switch"},
        new Game {Title="Fallout New Vegas", Price=10.00, Genre="Open World RPG", Rating="M", Platform="PC"},
        new Game {Title="League of Legends", Price=0.00, Genre="MOBA", Rating="T", Platform="PC"}
    };
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Game> allGamesFromData = AllGames.OrderBy(s => s.Title).ThenBy(p => p.Price).ToList();
        ViewBag.AllGames = allGamesFromData;
        return View();
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
