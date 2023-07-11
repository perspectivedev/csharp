// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here!
namespace DojoSurvey.Controllers;
public class DojoSurveyController : Controller   // Inheritance
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpPost("Results")]
    public ViewResult Results(string name, string location, string language, string comment)
    {
        ViewBag.Name = name;
        ViewBag.Location = location;
        ViewBag.Language = language;
        ViewBag.Comment = comment;
        return View();
    }
}

