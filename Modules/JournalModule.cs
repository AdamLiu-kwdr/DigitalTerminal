using System;
using System.Text;
using System.Collections.Generic;

using CyberArtDemo.Models;
using CyberArtDemo.Pages;

namespace CyberArtDemo.Modules
{
    public class JournalModule
    {
        //Only printing test page right now
        public void showJournalPage(int? id = 1){
            Journal testEntry = new Journal(){
                EntryId = "999",
                EntryTitle="test entry",
                Author="someone",
                Location="here",
                EntryTime = new DateTime(2019,9,9),
                Contents = new List<string>()
            };
            testEntry.Contents = generateDummyJournalCotent();
            JournalPage testPage = new JournalPage(testEntry);
            testPage.Show();
        }


        //Make dummy data for test purpose
        private List<string> generateDummyJournalCotent(){
            List<string> Contents = new List<string>();
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
            return(Contents);
        }
    }
    
}