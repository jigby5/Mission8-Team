using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission8_Team.Models;
using System.Diagnostics;

namespace Mission8_Team.Controllers;

public class HomeController : Controller
{
    private readonly TasksContext _context;
   
    public HomeController(TasksContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Quadrants()
    {
        var tasks = _context.Tasks
            .Include(t => t.Category)
            .Where(t => !t.Completed)
            .OrderBy(t => t.DueDate)
            .ToList();

        return View(tasks);
    }

    [HttpGet]
public IActionResult Create()
{
    ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
    return View(new TaskInstance());
}

[HttpPost]
public IActionResult Create(TaskInstance task)
{
    if (ModelState.IsValid)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
        return RedirectToAction("Quadrants");
    }

    ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName", task.CategoryId);
    return View(task);
}
    public IActionResult Edit(int id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
        if (task == null) return NotFound();

        ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName", task.CategoryId);
        return View(task);
    }

    [HttpPost]
    public IActionResult Edit(TaskInstance updated)
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Update(updated);
            _context.SaveChanges();
            return RedirectToAction("Quadrants");
        }

        ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName", updated.CategoryId);
        return View(updated);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var task = _context.Tasks
            .Include(t => t.Category)
            .FirstOrDefault(t => t.TaskId == id);

        if (task == null) return NotFound();

        return View(task);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
        if (task == null) return NotFound();

        _context.Tasks.Remove(task);
        _context.SaveChanges();

        return RedirectToAction("Quadrants");
    }

    // easiest for class: GET route to mark complete
    [HttpGet]
    public IActionResult Complete(int id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
        if (task == null) return NotFound();

        task.Completed = true;
        _context.SaveChanges();

        return RedirectToAction("Quadrants");
    }

    // we can keep this to just display errors more cleanly, I'll keep it at the bottom
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}