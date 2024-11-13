

using ManageExpenses;

class Program
{
    static void Main(string[] args)
    {
        var expenseManager = new ExpenseManager();

        while (true) 
        {
            Console.WriteLine("\nEscolhe uma opção:");
            Console.WriteLine("1. Adicionar Despesa");
            Console.WriteLine("2. Visualizar Despesas por Período");
            Console.WriteLine("3. Resumo Mensal de Despesas");
            Console.WriteLine("4. Sair");
            Console.WriteLine("Opção: ");

            var choice = Console.ReadLine();

            switch (choice) 
            {
                case "1":
                    Console.Write("Data da Despesa (dd/MM/yyyy: ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                    {
                        Console.Write("Valor da Despesa: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                        {
                            Console.Write("Categoria da Despesa (Ex: Alimentação, Transporte, etc.): ");
                            var category = Console.ReadLine();
                            expenseManager.AddExpense(date, amount, category);
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data inválida.");
                    }
                    break;

                case "2":
                    Console.Write("Data de Início (dd/MM/yyyy): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
                    {
                        Console.Write("Data de Fim (dd/MM/yyyy): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
                        {
                            expenseManager.ViewExpensesByDateRange(startDate, endDate);
                        }
                        else
                        {
                            Console.WriteLine("Data de fim inválida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data de iniício inválida.");
                    }
                    break;

                case "3":
                    Console.Write("Mês (1-12): ");
                    if (int.TryParse(Console.ReadLine(), out int month) && month >= 1 && month <= 12)
                    {
                        Console.Write("Ano (yyyy): ");
                        if (int.TryParse(Console.ReadLine(), out int year))
                        {
                            expenseManager.MonthlySummary(month, year);
                        }
                        else
                        {
                            Console.WriteLine("Mês invalido.");
                        }
                        
                    }
                    break;

                case "4":
                    Console.WriteLine("Encerrando o programa.");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção de 1 a 4.");
                    break;
            }
        }
    }
}