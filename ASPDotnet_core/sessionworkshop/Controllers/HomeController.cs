
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sessionworkshop.Models;

namespace sessionworkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("login")]
    public IActionResult Login(string Name)
    {
        HttpContext.Session.SetString("Name", Name);
        HttpContext.Session.SetInt32("UserNum", 22);
        return RedirectToAction("Privacy");
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpPost("add")]
    public IActionResult Add()
    {
        int? AddOne = HttpContext.Session.GetInt32("UserNum");
        System.Console.WriteLine(AddOne);
        AddOne++;
        System.Console.WriteLine(AddOne);
        HttpContext.Session.SetInt32("UserNum", (int)AddOne);
        return RedirectToAction("Privacy");
    }

    [HttpPost("minus")]
    public IActionResult Minus()
    {
        int? MinusOne = HttpContext.Session.GetInt32("UserNum");
        System.Console.WriteLine(MinusOne);
        MinusOne--;
        System.Console.WriteLine(MinusOne);
        HttpContext.Session.SetInt32("UserNum", (int)MinusOne);
        return RedirectToAction("Privacy");
    }

    [HttpPost("times")]
    public IActionResult Times()
    {
        int? TimesTwo = HttpContext.Session.GetInt32("UserNum");
        System.Console.WriteLine(TimesTwo);
        TimesTwo *= 2;
        System.Console.WriteLine(TimesTwo);
        HttpContext.Session.SetInt32("UserNum", (int)TimesTwo);
        return RedirectToAction("Privacy");
    }

    [HttpPost("rndNum")]
    public IActionResult Random()
    {
        int? rndNum = HttpContext.Session.GetInt32("UserNum");
        System.Console.WriteLine(rndNum);
        Random rnd = new Random();
        rndNum = rnd.Next(1, 23);
        System.Console.WriteLine(rndNum);
        HttpContext.Session.SetInt32("UserNum", (int)rndNum);
        return RedirectToAction("Privacy");
    }

    [HttpGet("privacy")]
    public IActionResult Privacy()
    {
        if(HttpContext.Session.GetString("Name") == null)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
