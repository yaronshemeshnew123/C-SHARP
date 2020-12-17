using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bank_project
{
    class Customer
    {
        protected int _id;
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        protected string _firstName;
        public string FirstName
        {
            set { _firstName = value; }
            get { return _firstName; }
        }
        protected string _lastName;
        public string LastName
        {
            set { _lastName = value; }
            get { return _lastName; }
        }
        protected string _address;
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        protected int _phoneNum;
        public int PhoneNum
        {
            set { _phoneNum = value; }
            get { return _phoneNum; }
        }

        public Customer()
        {
        }

        public Customer(int ID, string firstName, string lastName, string address, int phoneNum)
        {
            this._id = ID;
            this._firstName = firstName;
            this._lastName = lastName;
            this._address = address;
            this._phoneNum = phoneNum;
        }

        public override string ToString()
        {
            return base.ToString() + ": " +
                                     "\nID: " + this._id +
                                     "\nFirst Name: " + this._firstName +
                                     "\nLast Name: " + this._lastName +
                                     "\nAddress: " + this._address +
                                     "\nPhone Number: " + this._phoneNum;
        }
    }
}
