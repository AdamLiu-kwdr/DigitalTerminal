using System;
using System.Threading;

using CyberArtDemo.Pages;

namespace CyberArtDemo.Modules
{
    //This module controlls Main Menu related functions
    public class MainMenuModule
    {
        //Display Main Menu
        public void showMainMenu(){
            MenuPage mainMenu = new MenuPage(
                "Autek Mission Management system release 2.1.25",
                "Kernal 5.2.13.AuTek.RISC_V on an RISCV (ttyS1)",
                new string[]{"Mission Journal","Item Database","Residents Database","On-line Weapons","Body Diagnosis","System Settings"});
            mainMenu.OptionSelected += OnMainMenuOptionSelected; //Register eventHandler when user select optipon (press enter).
            mainMenu.Show();
        }
        
        //This is the event handler for MenuPage event "OptionSelected"
        protected virtual void OnMainMenuOptionSelected(object Sender, int selectedOption){
            switch (selectedOption)
            {
                case 1: //Mission Journal
                JournalModule Jmodule = new JournalModule();
                Jmodule.showJournalMenu();
                break;

                default:
                //throw new ArgumentException("Selected option is not implmented.","selectedOption");
                //Actually, the message below shouldn't be here, but there's no printing message code on menu page yet so...
                ConsoleFunctions.writeToCenter("Feature not avaiable yet!",13);
                Thread.Sleep(1000);
                break;
            }
        }
    }
}