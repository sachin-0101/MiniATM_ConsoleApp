using System;

//Author : Sachin Kotapure

namespace MiniATM_ConsoleApp
{
    // Declared class 
    public class Program
    {
        // User account details (for simplicity, I used hardcoded values)
        private string accountNumber = "1234567890"; // Account number
        private string name = "Sachin Kotapure"; // Account Holder Name
        private string pin = "1234"; // PIN code
        private double balance = 10000; // Account balance

        // Method to authenticate the user by checking the PIN
        private bool Authenticate(string enteredPin)
        {
            return enteredPin == pin;
        }

        // Method to check the account balance
        private void CheckProfile()
        {
            Console.WriteLine($"Account Holder Name : {name}");
            Console.WriteLine($"Account Number : {accountNumber}");
            Console.WriteLine($"Current Balance : {balance}");
        }

        // Method to check the account balance
        private void CheckBalance()
        {
            Console.WriteLine($"Your current balance is: {balance}");
        }

        // Method to withdraw money
        private void WithdrawMoney()
        {
            Console.Write("Enter amount to withdraw: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount <= balance && amount > 0)
            {
                balance -= amount;
                Console.WriteLine($"You have successfully withdrawn {amount}. Your new balance is {balance}.");
            }
            else if (amount > balance)
            {
                Console.WriteLine("Insufficient balance!");
            }
            else
            {
                Console.WriteLine("Invalid amount entered!");
            }
        }

        // Method to deposit money
        private void DepositMoney()
        {
            Console.Write("Enter amount to deposit: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"You have successfully deposited {amount}. Your new balance is {balance}.");
            }
            else
            {
                Console.WriteLine("Invalid amount entered!");
            }
        }

        // Method to display the ATM menu and handle user input
        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to the SK ATM!");
            Console.Write("Please enter your PIN: ");
            string enteredPin = Console.ReadLine();

            // Authenticate the user
            if (Authenticate(enteredPin))
            {
                bool exit = false;
                while (!exit)
                {
                    // Display the ATM menu
                    Console.WriteLine("\nATM Menu:");
                    Console.WriteLine("1. Check Balance");
                    Console.WriteLine("2. Withdraw Money");
                    Console.WriteLine("3. Deposit Money");
                    Console.WriteLine("4. Profile Info");
                    Console.WriteLine("5. Exit");

                    // Get the user's choice 
                    Console.Write("Select an option (1-4): ");
                    string choice = Console.ReadLine();

                    // Switch case implementation
                    switch (choice)
                    {
                        case "1":
                            CheckBalance();
                            break;
                        case "2":
                            WithdrawMoney();
                            break;
                        case "3":
                            DepositMoney();
                            break;
                        case "4":
                            CheckProfile();
                            break;
                        case "5":
                            Console.WriteLine("Thank you for using the ATM. Goodbye!");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please select a valid option.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect PIN! Access Denied.");
            }
        }

        // Main method to run the ATM
        static void Main(string[] args)
        {
            Program atm = new Program();
            atm.DisplayMenu();  
        }
    }
}
