using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageExpenses
{
    public class Expense
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }

        public Expense(DateTime date, decimal amount, string category)
        {
            Date = date;
            Amount = amount;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()} - {Category}: R${Amount:F2}";
        }
    }
}
