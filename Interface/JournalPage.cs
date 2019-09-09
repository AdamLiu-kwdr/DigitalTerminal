using System;
using System.Text;

namespace CyberArtDemo.Interface
{
    public class JournalPage
    {
        public string EntryId;
        public string EntryTitle;
        public string Location;
        public string Author;
        public DateTime EntryTime; 
        public string[] Contents; //Array for different pages

        public void Goto() //Display this Journal Page (Entry)
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
            ConsoleFunctions.writeTO($"{EntryTitle}",(int)(Console.BufferWidth*5/8)-(EntryTitle.Length)/2,2);

            StringBuilder sb = new StringBuilder("  This mission was to explore the first section of valley #26. Upon entry I found the cave full of giant white crystals."+
            " Item analyze shows these crystals are mostly made of SiO2 with minimal amount of Fe ion presence. Contiuning exploration."); //50
            
            // !!!USE regular expression!!!
            int entryBlockwidth = (int)(Console.BufferWidth*3/4)-2;
            if (sb.Length > entryBlockwidth) //avoid out of range exception
            {
                //To avoid using if() in for loop, divid sb.length by desired lenght and print the rest of the text later on.
                for (int i = 0; i < sb.Length/entryBlockwidth; i++)
                {
                    ConsoleFunctions.writeTO(sb.ToString(i*(entryBlockwidth-2),entryBlockwidth-2),(Console.BufferWidth/4)+2,i+3);
                }
                //  print the rest of the text, this line prevents string builder out of range exception
                ConsoleFunctions.writeTO(sb.ToString((sb.Length/entryBlockwidth)*entryBlockwidth-2,sb.Length%entryBlockwidth+2),(Console.BufferWidth/4)+2,sb.Length/entryBlockwidth+3);
            }
            else
            {
                ConsoleFunctions.writeTO(sb.ToString(0,sb.Length),(Console.BufferWidth/4)+2,3);
            }

            Console.ReadLine();
        }
    }
}