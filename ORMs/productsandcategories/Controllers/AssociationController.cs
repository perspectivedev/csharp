#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using productsandcategories.Models;

namespace productsandcategories.Controllers;

public class AssociationController : Controller
{
    private readonly ILogger<AssociationController> _logger;
    private MyContext _db;

    public AssociationController(ILogger<AssociationController> logger, MyContext context)
    {
        _logger = logger;
        _db = context;
    }

    public IActionResult Index()
    {
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
