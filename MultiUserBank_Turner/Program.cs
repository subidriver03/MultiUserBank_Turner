using System;

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        Console.WriteLine($"Bank initial balance: {bank.BankBalance:C}");

        while (true)
        {
            Console.WriteLine("\n1. Login\n2. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 2)
            {
                break;
            }

            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (bank.Login(username, password))
            {
                Console.WriteLine($"Welcome {username}!");

                while (true)
                {
                    Console.WriteLine($"\n{username}, choose an option:\n1. Check Balance\n2. Deposit\n3. Withdraw\n4. Logout");
                    Console.Write("Enter choice: ");
                    int userChoice = int.Parse(Console.ReadLine());

                    if (userChoice == 4)
                    {
                        Console.WriteLine("Logging out...");
                        break;
                    }

                    switch (userChoice)
                    {
                        case 1:
                            Console.WriteLine($"Your balance: {bank.GetBalance(username):C}");
                            break;
                        case 2:
                            Console.Write("Enter deposit amount: ");
                            decimal depositAmount = decimal.Parse(Console.ReadLine());
                            Console.WriteLine($"Your new balance: {bank.Deposit(username, depositAmount):C}");
                            break;
                        case 3:
                            Console.Write("Enter withdrawal amount: ");
                            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                            Console.WriteLine($"Your new balance: {bank.Withdraw(username, withdrawAmount):C}");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid username or password. Try again.");
            }
        }
    }
}
