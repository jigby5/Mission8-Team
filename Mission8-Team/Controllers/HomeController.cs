using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission8_Team.Models;

namespace Mission8_Team.Controllers;

public class HomeController : Controller
{
    private TasksContext _context;
    
    public HomeController(TasksContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    
    
    // we can keep this to just display errors more cleanly, I'll keep it at the bottom
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}