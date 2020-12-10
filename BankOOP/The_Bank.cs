using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BankOOP
{
    class The_Bank
    {
        private string name;
        private string username;
        private string password;
        private decimal Checkings;
        private decimal Savings;
        List<decimal> History = new List<decimal>();
        public The_Bank(string _name, string user, string _pass, decimal checkingbal)
        {
            name = _name;
            username = user;
            password = _pass;
            Checkings = checkingbal;
        }
        public string getName()
        { return name; }
        public void deposit(decimal input)
        {
            Checkings += input;
            History.Add(input);
        }
        public void deposit(decimal input, CheckorSave here)
        {
            History.Add(input);
            switch (here)
            {
                case CheckorSave.Check:
                    Checkings += input;
                    break;
                case CheckorSave.Save:
                    Savings += input;
                    break;
                default:
                    break;
            }
        }
        public void withdraw(decimal input, CheckorSave here)
        {
            input = 0 - input;
            History.Add(input);
            switch (here)
            {
                case CheckorSave.Check:
                    Checkings += input;
                    break;
                case CheckorSave.Save:
                    Savings += input;
                    break;
                default:
                    break;
            }
        }
        public string getUsername()
        {
                return username;
        }
        public decimal getCheckings()
        { return Checkings; }
        public decimal getSavings()
        { return Savings; }
        public bool verifylogin(string inputUsername, string inputPassword)
        {
            if (inputUsername == username.ToLower())
            {
                if (inputPassword == password)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public List<decimal> getHistory()
        { return History; }
        public List<string> ToString(List<decimal> help)
        {
            List<string> formatted = new List<string>();
            if ((getCheckings() + getSavings())<0) { 
                // Negative
                formatted.Add("Total Change to your account ($" + (0 - (getCheckings() + getSavings())) + ")"); 
            } else
            { 
                // Positive
                formatted.Add("Total Change to your account $" + (getCheckings() + getSavings()));
            }
            if ((getCheckings()) < 0) {
                // Negative
                formatted.Add("Your current Checking balance is ($" + (0 - getCheckings()) + ")");
            }
            else
            {
                // Positive
                formatted.Add("Your current Checking balance is $" + getCheckings());
            }
            if (( getSavings()) < 0)
            { 
                // Negative
                formatted.Add("Your current Savings balance is ($" + (0-getSavings()) + ")");
            }else
            {
                // Positive
                formatted.Add("Your current Savings balance is $" + getSavings());
            }
            for (int i = 0; i < help.Count; i++)
            {
                if (help[i] < 0)
                {
                    decimal numberFix = help[i] - 2 * help[i];
                    formatted.Add("Withdrawl: \t" + "$" + numberFix);
                }
                else { formatted.Add("Deposit \t" + "$" + help[i]); }
            }
            History.Clear();
            return formatted;
        }
    }
}