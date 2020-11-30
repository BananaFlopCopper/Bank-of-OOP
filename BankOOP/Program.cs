using System;

namespace BankOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running == true)
            {
                string init;
                char outit;
                bool loggedin = false;
                bool userincapable = true;
                Console.WriteLine("Welcome to very safe and secure bank of NotaScamBanking.");
                while (userincapable)
                {
                    Console.WriteLine("(L)ogin  (Q)uit");
                    init = Console.ReadLine();
                    init.ToLower();
                    if (!char.TryParse(init, out outit))
                    {
                        Console.WriteLine("Please enter a valid input (L, or Q).");
                    }
                    switch (outit)
                    {
                        case 'l':
                            if (false)
                            {
                                loggedin = true;
                            }
                            break;
                        case 'q':
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid input (L, or Q).");
                            break;
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
                    switch (outit)
                    {
                        case 'w':

                            break;
                        case 'd':

                            break;
                        case 'b':

                            break;
                        case 'l':
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
