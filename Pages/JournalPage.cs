using System;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using CyberArtDemo.Modules;
using CyberArtDemo.Models;

namespace CyberArtDemo.Pages
{
    public class JournalPage
    {
        private Journal journal;

        public JournalPage(Journal model){
            journal = model;
        }

        public void Show(int? page=1) //Display this Journal Page (Entry)
        {
            bool finished = false; //Temp
            while (!finished)
            {
                Console.Clear();
                //Draw blocks
                ConsoleFunctions.writeToCenter($"= Journal Entry {journal.EntryId} =",0);
                ConsoleFunctions.drawRectangle(8,(int)(Console.BufferWidth/4),0,1);
                ConsoleFunctions.drawRectangle(8,(int)(Console.BufferWidth/4),0,9);
                ConsoleFunctions.drawRectangle(16,(int)(Console.BufferWidth*3/4),(int)(Console.BufferWidth/4),1);

                //draw content
                ConsoleFunctions.writeTO($"Author: {journal.Author}",1,3);
                ConsoleFunctions.writeTO($"Time: {journal.EntryTime.ToString()}",1,4);
                ConsoleFunctions.writeTO($"Location: {journal.Location}",1,5);
                
                //Write instructions
                ConsoleFunctions.writeTO($"Up key: Previous entry",1,10);
                ConsoleFunctions.writeTO($"Down key: Next entry",1,11);
                ConsoleFunctions.writeTO($"Left key: Previous page",1,12);
                ConsoleFunctions.writeTO($"Right key: Next page",1,13);
                ConsoleFunctions.writeTO($"Backspace: Return to menu",1,14);

                //Print report
                ConsoleFunctions.writeTO($"{journal.EntryTitle} ({page}/2)",(int)(Console.BufferWidth*5/8)-(journal.EntryTitle.Length)/2,2);
                //I assume page starts with 1 and array starts with 0 right? (VB, get out.)
                var result = Regex.Matches(journal.Contents[(int)page-1],@"(.{1," + ((Console.BufferWidth*3/4)-4) +@"})(?:\s|$)");
                for (int i = 0; i < result.Count; i++)
                {
                    ConsoleFunctions.writeTO(result[i].ToString(),(Console.BufferWidth/4)+2,i+3);
                    Thread.Sleep(30);
                }
                var pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        page = 1; 
                        break;
                    case ConsoleKey.RightArrow:
                        page = 2; 
                    break;
                    case ConsoleKey.Backspace:
                        finished = true;
                    break;
                }    
            }
        }
    }
}