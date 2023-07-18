#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;


namespace login_and_registration.Models;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _db;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        // When our HomeController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        _db = context;
    }
    // New User
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [SessionCheck]
    [HttpGet("/success")]
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
            // Initializing a PasswordHasher object, providing our User class as its type            
            PasswordHasher<User> Hasher = new PasswordHasher<User>();   
            // Updating our newUser's password to a hashed version         
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);            
            //Save your user object to the database 
            _db.Add(newUser);
            _db.SaveChanges();
            System.Console.WriteLine(newUser);
            return RedirectToAction("Success");
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
        // If initial ModelState is valid, query for a user with the provided email        
        User? userInDb = _db.Users.FirstOrDefault(u => u.Email == userSubmission.EmailLogin);        
        // If no user exists with the provided email        
        if(userInDb == null)        
        {
            // Add an error to ModelState and return to View!            
            ModelState.AddModelError("EmailLogin", "Invalid Email/Password");            
            return View("Index");        
        }
        // Otherwise, we have a user, now we need to check their password                 
        // Initialize hasher object        
        PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();                    
        // Verify provided password against hash stored in db        
        var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.PasswordLogin);                                    // Result can be compared to 0 for failure        
        if(result == 0)        
        {            
            ModelState.AddModelError("EmailLogin", "Invalid credentials");
            return View("Index");
        } 
            HttpContext.Session.SetInt32("loggedUserId", userInDb.UserId);
            return RedirectToAction("Success");
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
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("loggedUserId");
        // Check to see if we got back null
        if(userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}