namespace ExpenseManagement.DB; 

 public record Expense 
 {
   public int Id { get; init; }
   public int EmployeeId { get; set; }
   public double Amount { get; set; }
   public string Currency {get; set; } = default!;
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
     return _expenses;
   } 

   public static Expense ? GetExpense(int id) 
   {
     return _expenses.SingleOrDefault(Expense => Expense.Id == id);
   } 

   public static Expense CreateExpense(Expense Expense) 
   {
     _expenses.Add(Expense);
     return Expense;
   }

   public static Expense UpdateExpense(Expense update) 
   {
     _expenses = _expenses.Select(Expense =>
     {
       if (Expense.Id == update.Id)
       {
         Expense.EmployeeId = update.EmployeeId;
         Expense.Amount = update.Amount;
         Expense.Currency = update.Currency;
         Expense.Description = update.Description;
       }
       return Expense;
     }).ToList();
     return update;
   }

   public static void RemoveExpense(int id)
   {
     _expenses = _expenses.FindAll(Expense => Expense.Id == id).ToList();
   }
 }