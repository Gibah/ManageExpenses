using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ManageExpenses
{
    public class ExpenseManager
    {
        private List<Expense> expenses;
        private readonly string filePath = "expenses.json";

        public ExpenseManager()
        {
            expenses = LoadExpensesFromFile();
        }

        public void AddExpense(DateTime date, decimal amount, string category)
        {
            var expense = new Expense(date, amount, category);
            expenses.Add(expense);
            SaveExpensesToFile();
            Console.WriteLine("Despesa adicionada com sucesso.");
        }

        public void ViewExpensesByDateRange(DateTime startDate, DateTime endDate) 
        {
            var filteredExpenses = expenses
                .Where(e => e.Date >= startDate && e.Date <= endDate)
                .ToList();

            if (filteredExpenses.Count == 0)
            {
                Console.WriteLine("Nenhuma despesa encontrada nesse período.");
            }
            else
            {
                Console.WriteLine("Despesas no período:");
                foreach (var expense in filteredExpenses)
                {
                    Console.WriteLine(expense);
                }
            }
        }

        public void MonthlySummary(int month, int year) 
        {
            var monthlyExpenses = expenses
                .Where(e => e.Date.Month == month && e.Date.Year == year)
                .GroupBy(e => e.Category)
                .Select(g => new { Category = g.Key, Total = g.Sum(e => e.Amount)})
                .ToList();

            if (monthlyExpenses.Count == 0)
            {
                Console.WriteLine("Nenhuma despesa encontrada para o mês especificado.");
            }
            else
            {
                Console.WriteLine($"Resumo de despesas para {month}/{year}:");
                foreach (var item in monthlyExpenses)
                {
                    Console.WriteLine($"{item.Category}: R${item.Total:F2}");
                }
            }
        }

        private void SaveExpensesToFile()
        {
            var json = JsonSerializer.Serialize(expenses);
            File.WriteAllText(filePath, json);
        }

        private List<Expense> LoadExpensesFromFile() 
        {
            if (File.Exists(filePath)) 
            {
                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Expense>>(json) ?? new List<Expense>();
            }
            return new List<Expense>() ;
        }
    }
}
