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
                int userstore = -1;
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
                                                userstore = i;
                                                Console.WriteLine("Welcome " + users[userstore].getName() + ".\n" + "Press any key to continue.");
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
                    Console.WriteLine("Welcome " + users[userstore].getUsername() + "\t Current Total Balance: $" 
                        + ( users[userstore].getCheckings()+ users[userstore].getSavings() ));
                    Console.WriteLine("(W)ithdraw   (D)eposit   (B)alance   (L)ogout");
                    init = Console.ReadLine();
                    init = init.ToLower();
                    if (!char.TryParse(init, out outit))
                    {
                        Console.WriteLine("Please enter a valid input (W, D, B, or L).");
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
                                //the actually important code here
                                string input;
                                decimal parsedinput;
                                switch (outit)
                                {
                                    case 'c':
                                        Console.WriteLine("How much would you like to Withdraw from Checkings?");
                                        input = Console.ReadLine();
                                        if (!decimal.TryParse(input, out parsedinput))
                                        {
                                            if (input.Contains('$'))
                                            {
                                                Console.WriteLine("Please enter a value. *do not enter the dollar sign*");
                                            }
                                            else { Console.WriteLine("Please enter a value."); }
                                        }
                                        users[userstore].withdraw(parsedinput, CheckorSave.Check);
                                        break;
                                    case 's':

                                        Console.WriteLine("How much would you like to Withdraw from Savings?");
                                        input = Console.ReadLine();
                                        if (!decimal.TryParse(input, out parsedinput))
                                        {
                                            if (input.Contains('$'))
                                            {
                                                Console.WriteLine("Please enter a value. *do not enter the dollar sign*");
                                            }
                                            else { Console.WriteLine("Please enter a value."); }
                                        }
                                        users[userstore].withdraw(parsedinput, CheckorSave.Save);
                                        break;
                                }
                                //
                                Console.WriteLine("\nPress any Key to Continue.");
                                Console.ReadKey();
                                Console.Clear();
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
                                         input = Console.ReadLine();
                                        if (!decimal.TryParse(input, out parsedinput))
                                        {
                                            if (input.Contains('$'))
                                            {
                                                Console.WriteLine("Please enter a value. *do not enter the dollar sign*");
                                            } else { Console.WriteLine("Please enter a value."); }
                                        }
                                        users[userstore].deposit(parsedinput,CheckorSave.Check);
                                        break;

                                    case 's':

                                        Console.WriteLine("How much would you like to deposit into Savings?");
                                        input = Console.ReadLine();
                                        if (!decimal.TryParse(input, out parsedinput))
                                        {
                                            if (input.Contains('$'))
                                            {
                                                Console.WriteLine("Please enter a value. *do not enter the dollar sign*");
                                            }
                                            else { Console.WriteLine("Please enter a value."); }

                                        }
                                        users[userstore].deposit(parsedinput, CheckorSave.Save);
                                        break;
                                }
                                Console.WriteLine("\nPress any Key to Continue.");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case 'b':   //Balance
                                if (users[userstore].getCheckings()<0)
                                {
                                    Console.WriteLine("Checkings: \t(" + (0-users[userstore].getCheckings()) + ")");
                                } else
                                {
                                    Console.WriteLine("Checkings: \t" + users[userstore].getCheckings());
                                }
                                if (users[userstore].getSavings() <0)
                                {
                                    Console.WriteLine("Savings: \t(" + (0-users[userstore].getSavings()) + ")");
                                } else
                                {
                                    Console.WriteLine("Savings: \t" + users[userstore].getSavings());
                                }
                                
                                if((users[userstore].getCheckings()+ users[userstore].getSavings())<0)
                                {
                                    users[userstore].withdraw(9000, CheckorSave.Check);
                                    Console.WriteLine("You qualify for a free deduction of your moneys. A free $9,000 charge has been added to your account.");
                                }
                                
                                Console.WriteLine("\nPress any Key to Continue.");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case 'l':   //Logout
                                List<string> formatted = new List<string>(users[userstore].ToString(users[userstore].getHistory()));
                                for(int i = 0; i<formatted.Count; i++)
                                {
                                    Console.WriteLine(formatted[i]);
                                }
                                loggedin = false;
                                Console.WriteLine("\nPress any Key to Continue.");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            default:
                                Console.WriteLine("Enter a valid input (W, D, B, or L).");
                                break;

                        }
                    }
                }
            }
        }
    }
}
