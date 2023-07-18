#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using productsandcategories.Models;

namespace productsandcategories.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    private MyContext _db;

    public ProductController(ILogger<ProductController> logger, MyContext context)
    {
        _logger = logger;
        _db = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Product> allProds =  _db.Products.ToList();
        ViewBag.allProds =  allProds;
        return View();
    }
    [HttpPost("product/create")]
    public IActionResult CreateProduct(Product newProd)
    {
        if(!ModelState.IsValid)
        {
            List<Product> allProds =  _db.Products.ToList();
            ViewBag.allProds =  allProds;
            return View("Index");
        }
            _db.Products.Add(newProd);
            _db.SaveChanges();
            return RedirectToAction("Index");
    }
    [HttpGet("/products/{productId}")]
    public IActionResult OneProduct(int productId)
    {
        Product? oneProduct = _db.Products.Include(p => p.Associations).ThenInclude(c => c.Category).FirstOrDefault(p => p.ProductId == productId);
        ViewBag.unassociatedCats = _db.Categories.Include(p => p.Associations).ThenInclude(p => p.Product).Where(e => !e.Associations.Any(c => c.ProductId == productId)).ToList();
        return View(oneProduct);
    }

    [HttpPost("products/{productId}/update")]
    public IActionResult AddCategory(int categoryId, int productId)
    {
        Association newCategory = new Association();
        newCategory.ProductId = categoryId;
        newCategory.CategoryId = productId;
        _db.Associations.Add(newCategory);
        _db.SaveChanges();
        return RedirectToAction("OneProduct", new {newCategory.ProductId});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
