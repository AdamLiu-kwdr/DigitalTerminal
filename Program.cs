using System;
using System.Threading;
using CyberArtDemo.Interface;
using System.Collections.Generic;

namespace CyberArtDemo
{
    class Program
    {
        private static int CursorCurrentX;
        private static int CursorCurrentY;

        static void Main(string[] args)
        {
            JournalPage testPage = new JournalPage(){
                EntryId = "999",
                EntryTitle="test entry",
                Author="someone",
                Location="here",
                EntryTime = new DateTime(2019,9,9),
                Contents = new List<string>()
            };
            testPage.Goto();

            //Init
             string userName ="";
             Console.Clear();
             CursorCurrentX = Console.CursorTop;
             CursorCurrentY = Console.CursorLeft;

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
                Console.SetCursorPosition(70,Console.CursorTop);
                Console.WriteLine("[  ok  ]");
                Thread.Sleep(60);
            }
            Console.Write($"Reached target Multi-User");
            Thread.Sleep(1000);

            //Login Screen
            Console.Clear();
            ConsoleFunctions.drawRectangle(10,Console.BufferWidth,0,0);
            ConsoleFunctions.writeToCenter("Welcome to Autek Mission Server! Please Login:",3);
            ConsoleFunctions.writeToCenter("User Name:",6);
            userName = Console.ReadLine();
            ConsoleFunctions.writeToCenter("User Passwod:",7);
            Console.Read();

            ConsoleFunctions.writeToCenter($"Welcome back {userName}! Preparing user enviorment for you...",11);
            Thread.Sleep(3000);
            Console.ReadLine();

            //Printing Dashboard(Main menu)
            UIMenu mainMenu = new UIMenu(
                "Autek Mission Management system release 2.1.25",
                "Kernal 5.2.13.AuTek.RISC_V on an RISCV (ttyS1)",
                new string[]{"Mission Journal","Item Database","Residents Database","On-line Weapons","Body Diagnosis","System Settings","Log out"});

            mainMenu.Goto();

            Console.ReadLine();
            //Leave this at the end or last line will get erased.
            //Console.SetCursorPosition(0,Console.BufferHeight-1);
        }
    }
}
