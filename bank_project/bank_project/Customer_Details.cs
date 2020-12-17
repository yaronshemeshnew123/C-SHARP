using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bank_project
{
    class Customer_Details:Bank
    {
        public static void Print (List<Customer> lCustomer, List<Account> lAccount, int IDNum)
        {
            for (int i = 0; i < lCustomer.Count; i++)
            {
                if (lCustomer[i].ID == IDNum)
                {
                    Console.WriteLine(lCustomer[i].ToString());
                }
            }
            for (int i = 0; i < lAccount.Count; i++)
            {
                if (lAccount[i].CustomerID == IDNum)
                {
                    Console.WriteLine(lAccount[i].ToString());
                }
            }
        }
    }
}
