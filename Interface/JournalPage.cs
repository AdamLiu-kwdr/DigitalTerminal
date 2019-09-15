using System;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace CyberArtDemo.Interface
{
    public class JournalPage
    {
        public string EntryId;
        public string EntryTitle;
        public string Location;
        public string Author;
        public DateTime EntryTime; 
        public List<string> Contents; //Array for different pages

        public void Goto(int? page=1) //Display this Journal Page (Entry)
        {
            // Moving this to controller later on, it's for generating the dummy content
            StringBuilder origin = new StringBuilder(); 
            origin.AppendLine("  This mission was to explore the first section of valley #26 and meetup with frontier team Delta at zero-thirty." + 
            " I expect the danger of the mission to be minimal. However I still carry a rail gun with me in "+
            "case the \"squids\" (Creature database entry 15543-20-1) wave moved faster than expected.");
            origin.AppendLine("");
            origin.AppendLine("Upon entry I found the cave have rich presence of unknow white crystals."+
            " Item analyze shows these crystals were made from 92% of SiO2, 5% of and minimal. (Item database entry 23523-0-0)");
             origin.AppendLine("");
            origin.Append("Contiuning exploration toward south.");
            Contents.Add(origin.ToString());
            //Page 2
            origin.Clear();
            origin.AppendLine("Rare metal mineral was found embedded inside the ceiling of the cave. However, detactor did not gave radioactive warning.");
            origin.AppendLine();
            origin.AppendLine("Due to lack of proper equippment. It is impossible to retrive samples from the cave ceiling. Another mission was suggested"+
            " for these rare metal could help the current research project conducted in the hardware research facility.");
            origin.AppendLine();
            origin.Append("Visual contact was made with Delta Frontier Base, proceeding now.");
            Contents.Add(origin.ToString()); 

            while (true)
            {
                Console.Clear();
                //Draw blocks
                ConsoleFunctions.writeToCenter($"= Journal Entry {EntryId} =",0);
                ConsoleFunctions.drawRectangle(8,(int)(Console.BufferWidth/4),0,1);
                ConsoleFunctions.drawRectangle(8,(int)(Console.BufferWidth/4),0,9);
                ConsoleFunctions.drawRectangle(16,(int)(Console.BufferWidth*3/4),(int)(Console.BufferWidth/4),1);

                //draw content
                ConsoleFunctions.writeTO($"Author: {Author}",1,3);
                ConsoleFunctions.writeTO($"Time: {EntryTime.ToString()}",1,4);
                ConsoleFunctions.writeTO($"Location: {Location}",1,5);
                
                //Write instructions
                ConsoleFunctions.writeTO($"Up key: Previous page",1,10);
                ConsoleFunctions.writeTO($"Down key: Next page",1,11);
                ConsoleFunctions.writeTO($"Left key: Previous entry",1,12);
                ConsoleFunctions.writeTO($"Right key: Next entry",1,13);
                ConsoleFunctions.writeTO($"Backspace: Return to menu",1,14);

                //Print report
                ConsoleFunctions.writeTO($"{EntryTitle} ({page}/2)",(int)(Console.BufferWidth*5/8)-(EntryTitle.Length)/2,2);
                //I assume page starts with 1 and array starts with 0 right? (VB, get out.)
                var result = Regex.Matches(Contents[(int)page-1],@"(.{1," + ((Console.BufferWidth*3/4)-4) +@"})(?:\s|$)");
                for (int i = 0; i < result.Count; i++)
                {
                    ConsoleFunctions.writeTO(result[i].ToString(),(Console.BufferWidth/4)+2,i+3);
                    Thread.Sleep(30);
                }
                var pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        page = 1; 
                        break;
                    case ConsoleKey.DownArrow:
                        page = 2; 
                    break;
                }    
            }
        }
    }
}