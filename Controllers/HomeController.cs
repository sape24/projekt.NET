using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projekt.NET.Models;
using Microsoft.EntityFrameworkCore;
using projekt.NET.Data;

namespace projekt.NET.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var recept = await _context.Recept.Include(r => r.Kategori).ToListAsync();
        return View(recept);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var recept = await _context.Recept.Include(r => r.Kategori).Include(r => r.Ingredienser).FirstOrDefaultAsync(r => r.Id == id);

        if (recept == null)
        {
            return NotFound();
        }

        return View(recept);
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
