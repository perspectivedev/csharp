#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;


namespace weddingplanner.Models;

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

    [SessionCheck]
    [HttpGet("/")]
    public IActionResult Success()
    {   
        int? loggedUserId = HttpContext.Session.GetInt32("loggedUserId");
        User? ViewModel = _db.Users.FirstOrDefault(user => user.UserId == loggedUserId);
        return View(ViewModel);
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
            return RedirectToAction("");
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
            return RedirectToAction("");
    }
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
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}