using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Classes
{
    internal class User
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNum { get; set; }
        private int _pin { get; set; }
        private double _accountBalance { get; set; }


        public User(string firstName,string lastName,string cardNum,int pin,double accBalance)
        {
            FirstName = firstName;
            LastName = lastName;
            CardNum = cardNum;
            _pin = pin;
            _accountBalance = accBalance;

        }
        
        public double GetAccBalance()
        {
            return _accountBalance;

        }
        public bool CheckPin(int pin)
        {
           if(_pin !=pin)
           {
                return false;
           };
            _pin = pin;
            return true;

        }

        public double Deposit(double amount)
        {
            return _accountBalance += amount;
        }

        public bool Withdrawal(double amount)
        {
            if (amount > _accountBalance) 
            return false;

            _accountBalance -= amount;
            return true;
        }
    }
}
