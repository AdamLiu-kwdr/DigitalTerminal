using System;
using System.Text;
using System.Collections.Generic;

using DigitalTerminal.Models;
using DigitalTerminal.Pages;

namespace DigitalTerminal.Modules
{
    public class JournalModule
    {
        //Show Journal Menu
        public void showJournalMenu(){
            string[] journalList = {"[9-9-2019] Valley#26 exploration","[9-23-2019] System development notes","[9-30-2019] To-Do list"};
            MenuPage journalMenu = new MenuPage("Mission Journals(Beta)","",journalList);
            journalMenu.OptionSelected += this.OnJournalSelected;
            journalMenu.Show();
        }

        //Display Journal from selected index (Unfinished, showing dummy data only.)
        protected virtual void OnJournalSelected(object sender,int index){
            switch (index)
            {
                //Entry 1
                case 1:
                Journal testEntry = new Journal(){
                EntryId = "1",
                EntryTitle="Valley#26 exploration",
                Author="[Name Here]",
                Location="Valley #26-1",
                EntryTime = new DateTime(2019,9,9),
                Contents = new List<string>()
                };
                testEntry.Contents = generateDummyJournalCotent(1);
                JournalPage testPage = new JournalPage(testEntry);
                testPage.Show();
                break;
                
                //Entry 2
                case 2:
                Journal testEntry2 = new Journal(){
                EntryId = "2",
                EntryTitle="System development notes",
                Author="Zephyrus",
                Location="System lab Z-1",
                EntryTime = new DateTime(2019,9,23),
                Contents = new List<string>()
                };
                testEntry2.Contents = generateDummyJournalCotent(2);
                JournalPage testPage2 = new JournalPage(testEntry2);
                testPage2.Show();
                break;

                //Entry3
                case 3:
                Journal testEntry3 = new Journal(){
                EntryId = "3",
                EntryTitle="To-Do list",
                Author="Zephyrus",
                Location="System lab Z-0",
                EntryTime = new DateTime(2019,9,30),
                Contents = new List<string>()
                };
                testEntry3.Contents = generateDummyJournalCotent(3);
                JournalPage testPage3 = new JournalPage(testEntry3);
                testPage3.Show();
                break;
            }
        }

        //Make dummy data for test purpose
        private List<string> generateDummyJournalCotent(int index){
            List<string> Contents = new List<string>();
            // Moving this to controller later on, it's for generating the dummy content
            StringBuilder origin = new StringBuilder(); 
            switch (index)
            {
                //Entry 1
                case 1:
                //page1
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
                break;

                //Entry2
                case 2:
                origin.AppendLine(" [Announcement #0029592489-SystemGroup-ZY]");
                origin.AppendLine(" Good day everyone, the mission system is now in white box phrase (public beta) and we're looking for volunteers."
                +"If anyone is interested in testing out the new system, please contact Mrs.Frosty at System group. She will help you fill in the form and set up the"+
                " test enviorment. Her office is in the complex SG-15X.");
                origin.AppendLine("");
                origin.Append("[Contiune next page]");
                Contents.Add(origin.ToString());
                origin.Clear();
                origin.AppendLine("Remember, The beta system is still unfinished. Tester could encounter random crashes, data lost or poor connection (Obviously that's why"+
                " we're doing public test.) so please DO NOT bring your active mission/ important files to the test. And don't wear your Android suit since Universal android"+
                " port is not ready yet. (Yes we know, we're working on that.)");
                origin.AppendLine("");
                origin.Append("-Zeyphrus");
                Contents.Add(origin.ToString());
                break;
                case 3:
                origin.AppendLine("1. Don't tell anyone outside SG the journal system is using hard coded data.");
                origin.AppendLine("2. Call Ark to test out the new Plasma weapon (ehehe).");
                origin.AppendLine("3. Write a sigh about \"Pardon for the weird [REDACTED] noise from my lab.\"");
                origin.AppendLine("4. Out of coffee, Argh.");
                origin.Append("5. High speed memory driver Ver.3 comes out next week, woohoo!");
                Contents.Add(origin.ToString());
                origin.Clear();
                origin.Append("[End of list]");
                Contents.Add(origin.ToString());
                break;
            }
            return(Contents);
        }
    }
    
}