using ExpenseManagement.DB;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
  {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contoso Expense Management", Description = "Contoso Expense Management", Version = "v1" });
  });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
  {
     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contoso Expense Management");
  });

app.MapGet("/expenses/{id}", (int id) => ExpenseManagementDB.GetExpense(id));
app.MapGet("/expenses", () => ExpenseManagementDB.GetExpenses());
app.MapPost("/expenses", (Expense expense) => ExpenseManagementDB.CreateExpense(expense));
app.MapPut("/expenses", (Expense expense) => ExpenseManagementDB.UpdateExpense(expense));
app.MapDelete("/expenses/{id}", (int id) => ExpenseManagementDB.RemoveExpense(id));

app.Run();
