using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bank_project
{
    class Account:Customer
    {
        protected int _customerID;
        public int CustomerID
        {
            set
            {
                _customerID = ID;
            }
            get
            {
                return _customerID;
            }
        }
        protected int _accountNum;
        public int AccountNum
        {
            set { _accountNum = value; }
            get { return _accountNum; }
        }
        protected double _accountBalance;
        public double AccountBalance
        {
            set { _accountBalance = value; }
            get { return _accountBalance; }
        }
        protected double _credit;
        public double Credit
        {
            set { _credit = value; }
            get { return _credit; }
        }

        public Account()
        {
        }

        public Account(int customerID, int accountNum, double accountBalance, double credit)
        {
            this._customerID = customerID;
            this._accountNum = accountNum;
            this._accountBalance = accountBalance;
            this._credit = credit;
        }

        public override string ToString()
        {
            return base.ToString() + ": " +
                                     "\nCustomer Name: " + FirstName + " " + LastName +
                                     "\nAccount Number: " + this._accountNum +
                                     "\nAccount Balance is: " + this._accountBalance +
                                     "\nCredit: " + this._credit;
        }
    }
}
