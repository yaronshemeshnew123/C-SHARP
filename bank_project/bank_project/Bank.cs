using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bank_project
{
    class Bank:Account
    {
        public Bank()
        {
        }
        public Bank(int IDNum)
        {
            _id = IDNum;
        }

        public Bank (int IDNum, int accountNumber)
        {
            _id = IDNum;
            _accountNum = accountNumber;
        }

        public List<Account> lAccount = new List<Account>();
        public List<Customer> lCustomer = new List<Customer>();

        public bool CustomerExistanceCheck(int IDNum)
        {
            bool answer = false;
            for (int i = 0; i < lCustomer.Count; i++)
            {
                if (lCustomer[i].ID == IDNum)
                {
                    answer = true;
                }
            }
            return answer;
        }
        public void AddNewCustomer(int IDNum)
        {
            Console.Write("enter your first name: ");
            string fName = Console.ReadLine();
            Console.Write("enter your last name: ");
            string lName = Console.ReadLine();
            Console.Write("enter your address: ");
            string address = Console.ReadLine();
            Console.Write("enter your phone number: ");
            int phoneNumber = int.Parse(Console.ReadLine());
            Customer customer = new Customer(IDNum, fName, lName, address, phoneNumber);
            lCustomer.Add(customer);
        }
        public bool AccountCustomerCheck(int IDNum)
        {
            bool answer=false;
            for (int i = 0; i < lAccount.Count; i++)
            {
                if (lAccount[i].CustomerID == IDNum)
                {
                    answer = true;
                }    
            }
            return answer;
        }
        public void CreateNewAccount(int IDNum)
        {
            Random a = new Random();
            int runNum = a.Next(100000, 999999);
            int accountNumber = runNum;
            Console.Write("enter your account balance: ");
            double accountBalanceSum = double.Parse(Console.ReadLine());
            Console.Write("enter your credit: ");
            double creditSum = double.Parse(Console.ReadLine());
            Account account = new Account(IDNum, accountNumber, accountBalanceSum, creditSum);
            lAccount.Add(account);
        }
        public void WithDraw(int IDNum)
        {
            Console.Write("Please enter a sum that you want to withdraw: ");
            double withdrawSum = double.Parse(Console.ReadLine());
            for (int i = 0; i < lAccount.Count; i++)
            {
                if (lAccount[i].CustomerID == IDNum)
                {
                    if (lAccount[i].AccountBalance >= withdrawSum)
                    {
                        lAccount[i].AccountBalance -= withdrawSum;
                    }
                    else
                    {
                        Console.WriteLine("You can't withdraw such a big sum");
                    }
                }
                else
                {
                    Console.WriteLine("Your account does not exist");
                }
            }
        }
        public void Deposit(int accountNumber, int IDNum)
        {
            Console.Write("Please enter a sum that you want to deposit: ");
            double depositSum = double.Parse(Console.ReadLine());
            for (int i = 0; i < lAccount.Count; i++)
            {
                if ((lAccount[i].CustomerID == IDNum) && (lAccount[i].AccountNum == accountNumber))
                {
                    lAccount[i].AccountBalance += depositSum;
                    Console.WriteLine("The action has been completed!");
                }
                else
                {
                    Console.WriteLine("Your account does not exist");
                }
            }
        }
    }
}
