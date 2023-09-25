#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using couponclipper_belt_exam_1.Models;


namespace couponclipper_belt_exam_1.Controllers;

[SessionCheck]
public class CouponController : Controller
{
    private readonly ILogger<CouponController> _logger;
    private MyContext _db;

    public CouponController(ILogger<CouponController> logger, MyContext context)
    {
        _logger = logger;
        _db = context;
    }
    // New User
    [HttpGet("coupons")]
    public IActionResult Index()
    {
        List<Coupon> allCoupons = _db.Coupons.Include(c => c.CouponTracker).ThenInclude(u => u.User).ToList();
        Console.WriteLine(allCoupons);
        return View(allCoupons);
    }

    [HttpGet("/users/{couponId}")]
    public IActionResult OneUser(Coupon userInDb, int userId, int couponId)
    {
        HttpContext.Session.SetInt32("LoggedUserId", userInDb.UserId);
        int? LocalVariable = HttpContext.Session.GetInt32("LoggedUserId");
        Console.WriteLine(LocalVariable);
        User? user = _db.Users.FirstOrDefault(u => u.UserId == userId);
        List<Coupon>? allCoupons = _db.Coupons.Include(ca => ca.CouponTracker).ThenInclude(u => u.UserId == userId).ToList();
        return View(allCoupons);
    }
    
    [HttpGet("coupons/new")]
    public IActionResult NewCoupon()
    {
        return View();
    }

    [HttpPost("coupons/create")]
    public IActionResult CreateCoupon(Coupon newCoupon)
    {
        if(!ModelState.IsValid)
        {
            return View("NewCoupon");
        }
        int? userId = HttpContext.Session.GetInt32("LoggedUserId");
        if(userId != null)
        {
            newCoupon.UserId = (int)userId;
        }
            _db.Coupons.Add(newCoupon);
            _db.SaveChanges();
        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
