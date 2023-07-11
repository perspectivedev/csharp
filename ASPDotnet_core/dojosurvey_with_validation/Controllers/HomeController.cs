#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dojosurvey_with_validation.Models;

namespace dojosurvey_with_validation.Controllers;

public class HomeController : Controller
{
    static Survey info;
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

    [HttpPost("privacy")]
    public IActionResult Privacy(Survey info)
    {
        if(ModelState.IsValid)
        {
            System.Console.WriteLine(info.Name);
            System.Console.WriteLine(info.Location);
            System.Console.WriteLine(info.Language);
            System.Console.WriteLine(info.Comment);
        } else {
            return View("Index");
        }
        return View(info);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
