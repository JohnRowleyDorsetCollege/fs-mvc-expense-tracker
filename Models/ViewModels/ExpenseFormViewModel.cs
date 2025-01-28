using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseTracker.Models.ViewModels;

public class ExpenseFormViewModel
{
    public Expense Expense { get; set; } = new();
    public List<SelectListItem> ExpenseCategories = new List<SelectListItem>();
}