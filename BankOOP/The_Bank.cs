using System;
using System.Collections.Generic;
using System.Text;

namespace BankOOP
{
    class The_Bank
    {
        private bool loggedIn;
        private string name;
        private string username;
        private string password;
        private decimal balance;
        The_Bank(string _name, string user, string pass_safe, decimal initialBal)
        {
            name = _name;
            username = user;
            password = pass_safe;
            balance = initialBal;
        }
        public string getName()
        {
            if (loggedIn == true)
            {
                return name;
            }
            else return "";
        }
        public string getUsername()
        {
            if (loggedIn == true)
            {
                return username;
            }
            else return "";
        }
        public decimal getBalance()
        {
            if (loggedIn == true)
            {
                return balance;
            }
            else return 0m;
            
        }
        public bool verifylogin(string inputUsername, string inputPassword)
        {
            if (inputUsername == username)
            {
                if (inputPassword == password)
                {
                    loggedIn = true;
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
