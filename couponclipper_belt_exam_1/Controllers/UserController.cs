#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using couponclipper_belt_exam_1.Models;


namespace couponclipper_belt_exam_1.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private MyContext _db;

    public UserController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;
        _db = context;
    }
    // New User
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
    
    // Registration
    [HttpPost("users/create")]   
    public IActionResult CreateUser(User newUser)
    {        
        if(!ModelState.IsValid)        
        {
            return View("Index");
        } else {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _db.Add(newUser);
            _db.SaveChanges();
            System.Console.WriteLine(newUser);
            return RedirectToAction("Index", "Coupon");
        }   
    }


    // Login 
    [HttpPost("/users/login")]
    public IActionResult Login(LoginUser userSubmission)
{    
    if(!ModelState.IsValid)    
    {        
        return View("Index");
    } else {
        User? userInDb = _db.Users.FirstOrDefault(u => u.Email == userSubmission.EmailLogin);
        if(userInDb == null)        
        {
            ModelState.AddModelError("EmailLogin", "Invalid Email/Password");            
            return View("Index");        
        }
        PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
        var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.PasswordLogin); // Result can be compared to 0 for failure
        if(result == 0)
        {            
            ModelState.AddModelError("EmailLogin", "Invalid credentials");
            return View("Index");
        } 
            HttpContext.Session.SetInt32("loggedUserId", userInDb.UserId);
            HttpContext.Session.SetString("UserName", userInDb.UserName);
            HttpContext.Session.SetString("Email", userInDb.Email);
            return RedirectToAction("Index", "Coupon");
    }
}
    [HttpPost("/user/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
