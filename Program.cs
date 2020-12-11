using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;

using DigitalTerminal.Modules;
using DigitalTerminal.Pages;
using DigitalTerminal.Models;

namespace DigitalTerminal
{
    class Program
    {

        static void Main(string[] args)
        {
            // //Init
            string userName = "";
            Console.Clear();
            printStartUpScreen();

            // //Login Screen
            Console.Clear();
            ConsoleFunctions.drawRectangle(10, Console.BufferWidth, 0, 0);
            ConsoleFunctions.writeToCenter("Welcome to Autek Mission Server! Please Login:", 3);
            ConsoleFunctions.writeToCenter("User Name:", 6);
            userName = Console.ReadLine();
            ConsoleFunctions.writeToCenter("User Passwod:", 7);
            Console.Read();

            ConsoleFunctions.writeToCenter($"Welcome back {userName}! Preparing user enviorment for you...", 11);
            Thread.Sleep(3000);
            Console.ReadLine();

            //Printing Dashboard(Main menu)
            MainMenuModule MMenuModule = new MainMenuModule();
            MMenuModule.showMainMenu(); //This method will lock the thread until logout.

            //Menu exited, Clean up code here before shutdown.
            Console.Clear();
            Console.Write("Thank you for using Autek Mission Server, Good bye!");
        }

        //ShowStartUp Screen
        private static void printStartUpScreen()
        {
            //Pring connecting Screen
            Console.Clear();
            Thread.Sleep(500);
            Console.WriteLine("Connecting to Autek Mission server BR1...");
            Thread.Sleep(1000);
            Console.WriteLine($"Server BR1 said Hi. "/*Hello User {userName}."*/);
            Thread.Sleep(300);
            Console.WriteLine();
            Console.WriteLine("INIT:Creating User enviorment");
            Console.WriteLine("Entering Non interactive start-up");
            Console.WriteLine("");
            Thread.Sleep(100);

            string[] Daemons = new string[] {"auditd","SystemLogger","KernalLogger","Mount POSIX file system","Mount Debug file system","portmap",
            "firewalld","NFS statd","RD monitor","System message bus","Virtuald","mariaDB","ssh.d","Login-service","Network manager"};
            foreach (var Daemon in Daemons)
            {
                Console.Write($"Starting: {Daemon}");
                Console.SetCursorPosition(70, Console.CursorTop);
                Console.WriteLine("[  ok  ]");
                Thread.Sleep(60);
            }
            Console.Write($"Reached target Multi-User");
            Thread.Sleep(1000);
        }
    }
}
