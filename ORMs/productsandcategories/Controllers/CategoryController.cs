#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using productsandcategories.Models;

namespace productsandcategories.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private MyContext _db;

    public CategoryController(ILogger<CategoryController> logger, MyContext context)
    {
        _logger = logger;
        _db = context;
    }

    [HttpGet("/categories")]
    public IActionResult Index()
    {
        List<Category> allCats =  _db.Categories.ToList();
        ViewBag.allCats =  allCats;
        return View();
    }

     [HttpPost("categories/create")]
    public IActionResult CreateCategory(Category newCats)
    {
        if(!ModelState.IsValid)
        {
            List<Category> allCats  =  _db.Categories.ToList();
            ViewBag.allCats  =  allCats ;
            return View("Index");
        }
            _db.Categories.Add(newCats);
            _db.SaveChanges();
            return RedirectToAction("Index");
    }

    [HttpGet("/categories/{categoryId}")]
    public IActionResult OneCategory(int categoryId)
    {
        Category? oneCategory = _db.Categories.Include(c => c.Associations).ThenInclude(p => p.Product).FirstOrDefault(c => c.CategoryId == categoryId);
        List<Product> products = _db.Products.Include(p => p.Associations).ThenInclude(c => c.Category).Where(e => !e.Associations.Any(c => c.CategoryId == categoryId)).ToList();
        ViewBag.unassociatedProds = products;
        return View(oneCategory);
    }
    
    [HttpPost("categories/{categoryId}/update")]
        public IActionResult AddProduct(int productId, int categoryId)
    {
        Association newProduct = new Association();
        newProduct.CategoryId = categoryId;
        newProduct.ProductId = productId;
        _db.Associations.Add(newProduct);
        _db.SaveChanges();
        return RedirectToAction("OneCategory", new {newProduct.CategoryId});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
