using System;
using System.Collections.Generic;

namespace BankOOP
{
    enum CheckorSave
    {
        Check,
        Save
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            The_Bank Elmer = new The_Bank("Elmer Fudd", "efudd", "efudd1", 345.00m);
            The_Bank Bugs = new The_Bank("Bugs Bunny", "bbunny", "bbunny1", 1722.12m);
            The_Bank Tweety = new The_Bank("Tweety Bird", "tbird", "tbird1", 45.44m);
            while (running)
            {
                List < The_Bank > users = new List<The_Bank>();
                List<string> usernames = new List<string>();
                users.Add(Elmer);
                users.Add(Bugs);
                users.Add(Tweety);
                int user = -1;
                for (int i = 0; i < users.Count; i++)
                {
                    usernames.Add(users[i].getUsername());
                }
                string init;
                char outit;
                bool loggedin = false;
                Console.WriteLine("Welcome to very safe and secure bank of NotaScamBanking.");
                while (!loggedin)
                {
                    Console.WriteLine("(L)ogin  (Q)uit");
                    init = Console.ReadLine();
                    init = init.ToLower();
                    if (!char.TryParse(init, out outit))
                    {
                        Console.WriteLine("Please enter a valid input (L, or Q).");
                    }
                    else
                    {
                        switch (outit)
                        {
                            case 'l':   //Login
                                string username;
                                string password;
                                while (!loggedin)
                                {
                                    Console.WriteLine("Please enter your username: ");
                                    username = Console.ReadLine();
                                    username = username.ToLower();
                                    if (usernames.Contains(username))
                                    {
                                        Console.WriteLine("Please enter your password:");
                                        password = Console.ReadLine();
                                        for (int i = 0; i < users.Count; i++)
                                        {
                                            if (users[i].verifylogin(username, password))
                                            {

                                                loggedin = true;
                                                user = i;
                                                Console.WriteLine("Welcome " + users[user].getName() + ".\n" + "Press any key to continue.");
                                                Console.ReadKey();
                                                Console.Clear();

                                            }
                                        }
                                    }
                                    else { Console.WriteLine("Not a valid username"); }
                                }
                                break;
                            case 'q':   //Quit
                                running = false;
                                return;
                            default:
                                Console.WriteLine("Please enter a valid input (L, or Q).");
                                break;
                        }
                    }
                }

                while (loggedin)
                {
                    Console.WriteLine("Welcome " + users[user].getUsername() + "\t Current Total Balance: $" 
                        + ( users[user].getCheckings()+ users[user].getSavings() ));
                    Console.WriteLine("(W)ithdraw   (D)eposit   (B)alance   (L)ogout");
                    init = Console.ReadLine();
                    init = init.ToLower();
                    if (!char.TryParse(init, out outit))
                    {
                        Console.WriteLine("Please enter a valid input (W, D, B, or L).");
                        anyKey();
                    }
                    else
                    {
                        switch (outit)
                        {
                            case 'w':   //Withdraw
                                Console.WriteLine("(C)heckings, or (S)avings?");
                                init = Console.ReadLine();
                                init = init.ToLower();
                                if (!char.TryParse(init, out outit))
                                {
                                    Console.WriteLine("Please enter a valid input (C, or S).");
                                }

                                switch (outit)
                                {
                                    case 'c':   //Checkings
                                        Console.WriteLine("How much would you like to Withdraw from Checkings?");
                                        if (users[user].getCheckings() < 0)
                                        {   // Negative
                                            Console.WriteLine("Current Checkings: \t($" + (0 - users[user].getCheckings()) + ")");
                                        }
                                        else
                                        {   // Positive
                                            Console.WriteLine("Current Checkings: \t$" + users[user].getCheckings());
                                        }
                                        users[user].withdraw(tryParseNum(), CheckorSave.Check);
                                        break;

                                    case 's':   //Savings
                                        Console.WriteLine("How much would you like to Withdraw from Savings?");
                                        if (users[user].getSavings() < 0)
                                        {   // Negative
                                            Console.WriteLine("Current Savings: \t($" + (0 - users[user].getSavings()) + ")");
                                        }
                                        else
                                        {   // Positive
                                            Console.WriteLine("Current Savings: \t$" + users[user].getSavings());
                                        }
                                        users[user].withdraw(tryParseNum(), CheckorSave.Save);
                                        break;
                                }
                                //
                                anyKey();
                                break;
                            case 'd':   //Deposit
                                Console.WriteLine("(C)heckings, or (S)avings?");
                                init = Console.ReadLine();
                                init = init.ToLower();
                                if (!char.TryParse(init, out outit))
                                {
                                    Console.WriteLine("Please enter a valid input (C, or S).");
                                }

                                //the actually important code here
                                switch (outit)
                                {
                                    case 'c':
                                        Console.WriteLine("How much would you like to deposit into Checkings?");
                                        users[user].deposit(tryParseNum(), CheckorSave.Check);
                                        if (users[user].getCheckings() < 0)
                                        {   // Negative
                                            Console.WriteLine("New Checkings Balance: \t($" + (0 - users[user].getCheckings()) + ")");
                                        }
                                        else
                                        {   // Positive
                                            Console.WriteLine("New Checkings Balance: \t$" + users[user].getCheckings());
                                        }
                                        break;

                                    case 's':

                                        Console.WriteLine("How much would you like to deposit into Savings?");
                                        users[user].deposit(tryParseNum(), CheckorSave.Save);
                                        if (users[user].getSavings() < 0)
                                        {   // Negative
                                            Console.WriteLine("New Savings Balance: \t($" + (0 - users[user].getSavings()) + ")");
                                        }
                                        else
                                        {   // Positive
                                            Console.WriteLine("New Savings Balance: \t$" + users[user].getSavings());
                                        }
                                        break;
                                }
                                anyKey();
                                break;

                            case 'b':   //Balance
                                if (users[user].getCheckings()<0) 
                                {   // Negative
                                    Console.WriteLine("Checkings: \t($" + (0-users[user].getCheckings()) + ")");
                                } else
                                {   // Positive
                                    Console.WriteLine("Checkings: \t$" + users[user].getCheckings());
                                }
                                if (users[user].getSavings() <0)
                                {   // Negative
                                    Console.WriteLine("Savings: \t($" + (0-users[user].getSavings()) + ")");
                                } else
                                {   // Positive
                                    Console.WriteLine("Savings: \t$" + users[user].getSavings());
                                }

                                anyKey();
                                break;

                            case 'l':   //Logout
                                List<string> formatted = new List<string>(users[user].ToString(users[user].getHistory()));
                                for(int i = 0; i<formatted.Count; i++)
                                {
                                    Console.WriteLine(formatted[i]);
                                }
                                loggedin = false;
                                anyKey();
                                break;

                            default:
                                Console.WriteLine("Enter a valid input (W, D, B, or L).");
                                anyKey();
                                break;

                        }
                    }
                }
            }
        }
        public static void anyKey()
        {
            Console.WriteLine("\nPress any Key to Continue.");
            Console.ReadKey();
            Console.Clear();
        }
        public static decimal tryParseNum()
        {
            string input;
            decimal parsedinput =0m;
            bool complete = false;
            while (!complete) {
                input = Console.ReadLine();

                if (!decimal.TryParse(input, out parsedinput))
                {
                    if (input.Contains('$'))
                    {
                        Console.WriteLine("Please enter a value. *do not enter the dollar sign*");
                    }
                    else { Console.WriteLine("Please enter a value."); }

                }
                else if (input.Contains('-'))
                {
                    Console.WriteLine("Cannot be negative");
                }
                else
                {
                    complete = true;
                }
            }
            return parsedinput;
        }
    }
}
