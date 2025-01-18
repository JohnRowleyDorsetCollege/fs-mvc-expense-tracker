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
    
    public IActionResult CreateEditExpense(int? Id)
    {
       _logger.LogInformation("Create Expense");
       if (Id != null)
       {
           var item = _context.Expenses.Find(Id);
           return View(item);
       }
       return View();
    }
    
    public IActionResult DeleteExpense(int Id)
    {
        _logger.LogInformation("Delete Expense");
        var item = _context.Expenses.Find(Id);
        
        if (item != null)
        {
            _context.Expenses.Remove(item);
            _context.SaveChanges();
        }
       
        return RedirectToAction("Index");
    }
    public IActionResult CreateEditExpenseForm(Expense model)
    {
        if (model.Id == 0)
        {
            _logger.LogInformation($"Creating Expense {model.Id}: {model.Description}");
            _context.Expenses.Add(model);
          
           
        }
        else
        {
            _logger.LogInformation($"Updating Expense {model.Id}: {model.Description}");
            _context.Expenses.Update(model);
        }
        _context.SaveChanges();
        _logger.LogInformation($"Saving Expense {model.Id}: {model.Description}");
        return RedirectToAction("Index");
    }
}