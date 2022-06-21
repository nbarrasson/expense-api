namespace ExpenseManagement.DB; 

 public record Expense 
 {
   public int Id { get; init; }
   public int EmployeeId { get; set; }
   public double Amount { get; set; }
   public string ? Currency {get; set; }
   public string ? Description { get; set; }
 }

 public class ExpenseManagementDB
 {
   private static List<Expense> _expenses = new List<Expense>()
   {
     new Expense{ Id=1, EmployeeId=6554, Amount=1542.45, Currency="euro", Description="Travel to Redmond" },
     new Expense{ Id=2, EmployeeId=5489, Amount=120.60, Currency="dollar", Description="Restaurant with customer" },
     new Expense{ Id=3, EmployeeId=1258, Amount=800.90, Currency="euro", Description="Travel to London" }     
   };

   public static List<Expense> GetExpenses() 
   {
    // Return a copy of the list
     return _expenses;
   } 

   public static Expense ? GetExpense(int id) 
   {
    // Return the expense with the given id or null if not found
    return _expenses.FirstOrDefault(Expense => Expense.Id == id);
   } 

   public static Expense CreateExpense(Expense expense) 
   {
    // Add the expense if it doesn't already exist otherwise throw an exception
    if (_expenses.Any(Expense => Expense.Id == expense.Id))
    {
      throw new Exception("Expense already exists");
    }
    _expenses.Add(expense);
    return expense;
    }
    
   public static Expense UpdateExpense(Expense update) 
   {
    // Update the expense with the given id if it exists otherwise throw an exception
    var expense = _expenses.FirstOrDefault(Expense => Expense.Id == update.Id);
    if (expense == null)
    {
      throw new Exception("Expense not found");
    }
    expense.EmployeeId = update.EmployeeId;
    expense.Amount = update.Amount;
    expense.Currency = update.Currency;
    expense.Description = update.Description;
    return expense;
    }
    
   public static void RemoveExpense(int id)
   {
    // Remove the Expense
    _expenses = _expenses.Where(Expense => Expense.Id != id).ToList();
   }
 }