using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

public class ExpenseController : Controller
{
    private readonly ILogger<ExpenseController> _logger;
    private readonly ExpenseDbContext _context;

    public ExpenseController(ILogger<ExpenseController> logger, ExpenseDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        var expenses = _context.Expenses.ToList();
       
        return View(expenses);
    }
    
    public IActionResult CreateEditExpense()
    {
       _logger.LogInformation("Create Expense");
        return View();
    }
    public IActionResult CreateEditExpenseForm(Expense model)
    {
        _context.Expenses.Add(model);
        _context.SaveChanges();
        _logger.LogInformation($"Saving Expense {model.Id}: {model.Description}");
        return RedirectToAction("Index");
    }
}