namespace ExpenseTracker.Models;

public class Expense
{
    public int Id { get; set; }
    
    public string? Description { get; set; } = string.Empty;
    public decimal Value { get; set; }
}