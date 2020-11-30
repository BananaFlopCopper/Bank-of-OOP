using System;
using System.Collections.Generic;

namespace BankOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running == true)
            {
                The_Bank Elmer = new The_Bank("Elmer Fudd", "efudd", "efudd1", 345.00m);
                The_Bank Bugs = new The_Bank("Bugs Bunny", "bbunny", "bbunny1", 1722.12m);
                The_Bank Tweety = new The_Bank("Tweety Bird", "tbird", "tbird1", 45.44m);
                List < The_Bank > users = new List<The_Bank>();
                List<string> usernames = new List<string>();
                users.Add(Elmer);
                users.Add(Bugs);
                users.Add(Tweety);
                int userstore;
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
                    init.ToLower();
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
                                    username.ToLower();
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
                                break;
                            default:
                                Console.WriteLine("Please enter a valid input (L, or Q).");
                                break;
                        }
                    }
                }

                while (loggedin)
                {
                    Console.WriteLine("(W)ithdraw   (D)eposit   (B)alance   (L)ogout");
                    init = Console.ReadLine();
                    init.ToLower();
                    if (!char.TryParse(init, out outit))
                    {
                        Console.WriteLine("Please enter a valid input (W, D, B, or L).");
                    }
                    else
                    {
                        switch (outit)
                        {
                            case 'w': //Withdraw

                                break;
                            case 'd': //Deposit

                                break;
                            case 'b': //Balance

                                break;
                            case 'l': //Logout
                                      
                                //more work required!
                                loggedin = false;
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
