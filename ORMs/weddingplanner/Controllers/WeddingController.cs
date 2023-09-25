#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using weddingplanner.Models;

namespace weddingplanner.Controllers;

public class WeddingController : Controller
{
    private readonly ILogger<WeddingController> _logger;
    private MyContext _db;

    public WeddingController(ILogger<WeddingController> logger, MyContext context)
    {
        _logger = logger;
        _db = context;
    }
    

    [HttpGet("wedding")]
    public IActionResult Index()
    {
        List<Wedding> allWeds = _db.Weddings.Include(w => w.Guests).ThenInclude(u => u.User).ToList();
        return View(allWeds);
    }

    [HttpGet("wedding/new")]
    public IActionResult NewWedding()
    {
        return View();
    }

    [HttpPost("wedding/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if(!ModelState.IsValid)
        {
            return View("NewWedding");
        }
            int? userId = HttpContext.Session.GetInt32("loggedUserId");
        if(userId != null)
        {
            newWedding.UserId = (int)userId;
        }
            _db.Weddings.Add(newWedding);
            _db.SaveChanges();
            return RedirectToAction("Index");
    }

    [HttpGet("wedding/{weddingId}")]
    public IActionResult OneWedding( int weddingId)
    {
        Wedding? oneWedding = _db.Weddings.Include(g => g.Guests).ThenInclude(u => u.User).FirstOrDefault(w => w.WeddingId == weddingId);
        return View(oneWedding);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost("weddingrsvp/create")]
    public IActionResult WedRsvps(int weddingId)
    {
        int? userId = HttpContext.Session.GetInt32("loggedUserId");
        if(userId == null)
        {
            return RedirectToAction("Index", "User");
        }
        WeddingRsvp? currRsvp = _db.WeddingRsvps.FirstOrDefault(r => r.UserId == userId && r.WeddingId == weddingId);
        if(currRsvp != null)
        {
            _db.WeddingRsvps.Remove(currRsvp);
        }
        else 
        {
            WeddingRsvp? newRsvp = new WeddingRsvp()
            {
                WeddingId = weddingId,
                UserId = userId.Value
            };
            _db.WeddingRsvps.Add(newRsvp);
        }
        _db.SaveChanges();
        return RedirectToAction("Index", "Wedding");
    }

    [HttpPost("wedding/destroy/{weddingId}")]
    public IActionResult DeleteWedding(int weddingId)
    {
        Wedding? user = _db.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
        if(user != null)
        {
            _db.Weddings.Remove(user);
            _db.SaveChanges();
        }
        return RedirectToAction("Index", "User");
    }

}

public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? userId = context.HttpContext.Session.GetInt32("loggedUserId");
        if(userId == null)
        {
            context.Result = new RedirectToActionResult("Index", "User", null);
        }
    }
}

                                    // @if(hobby)
                                    // {
                                    //     <button type="submit" class="btn btn-primary">Add to Hobbies</button>
                                    // }