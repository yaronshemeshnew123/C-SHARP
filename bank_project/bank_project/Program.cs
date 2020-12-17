using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bank_project
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            int ID = 0, accountNum = 0;
            for (int i=0; i<5; i++)
            {
                Console.WriteLine("Welcome to our bank system!" +
                            "\nPress 1 if you're a new customer. We'll create your profile and a bank account" +
                            "\nPress 2 if you want to show your profile and account details" +
                            "\nPress 3 if you want to withdraw a sum of money" +
                            "\nPress 4 if you want to deposit a sum of money" +
                            "\nPress 0 if you want to exit");
                int caseNum = int.Parse(Console.ReadLine());
                switch (caseNum)
                {
                    case 1:
                        Console.Write("Please enter your ID: ");
                        ID = int.Parse(Console.ReadLine());
                        if (bank.CustomerExistanceCheck(ID) == false)
                        {
                            bank.AddNewCustomer(ID);
                            if (bank.AccountCustomerCheck(ID) == false)
                            {
                                bank.CreateNewAccount(ID);
                            }
                        }
                        else
                        {
                            Console.WriteLine("You're already a bank customer");
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Write("Please enter your ID: ");
                        ID = int.Parse(Console.ReadLine());
                        Customer_Details.Print(bank.lCustomer, bank.lAccount, ID);
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.Write("Please enter your ID: ");
                        ID = int.Parse(Console.ReadLine());
                        bank.WithDraw(ID);
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Write("Please enter your bank account number: ");
                        accountNum = int.Parse(Console.ReadLine());
                        Console.Write("Please enter your ID: ");
                        ID = int.Parse(Console.ReadLine());
                        bank.Deposit(accountNum, ID);
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Invalid operation number");
                        Console.WriteLine();
                        break;
                }
            } 
        }
    }
}
