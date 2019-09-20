using System;
using System.Threading;

using CyberArtDemo.Modules;

namespace CyberArtDemo.Pages
{
    //A class represents A menu screen
    public class MenuPage
    {
        private string _MenuTitle = "";
        private string _MenuSubTitle = "";

        private string[] _Options = {};

        private int selectedOption = 1;

        bool isFinished = false;

        //Properties
        public string getTitle { get{return _MenuTitle;}}
        public string getSubTitle { get{return _MenuSubTitle;}}
        public string[] GetOptions {get{return _Options;}}

        public MenuPage(string Title,string SubTitle,string[] Options){
            _MenuTitle = Title;
            _MenuSubTitle = SubTitle;
            _Options = Options;
        }

        //Show this menu to the screen
        public void Show()
        {
            //Draw blocks and menu properties
            Console.Clear();
            Console.WriteLine();
            ConsoleFunctions.drawRectangle(15,Console.BufferWidth-1,0,0);
            ConsoleFunctions.writeToCenter(_MenuTitle,1);
            ConsoleFunctions.writeToCenter(_MenuSubTitle,2);

            //Display all Options
            for (int i = 0; i < _Options.Length; i++)
            {
                Thread.Sleep(30);
                ConsoleFunctions.writeToCenter($"({i+1}) {_Options[i].ToString()}",4+i);
            }

            //Remember current background/text color
            var currentBgColor = Console.BackgroundColor;
            var currentTxtColor = Console.ForegroundColor;
            //Draw selected option and wait for input
            while (!isFinished)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                ConsoleFunctions.writeToCenter($"({selectedOption}) {_Options[selectedOption-1].ToString()}",4+selectedOption-1);
                Console.ForegroundColor = currentTxtColor;
                Console.BackgroundColor = currentBgColor;
                
                //Read user input
                var pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    //Options are printed from top to bottom
                    case ConsoleKey.UpArrow:
                        if (!(selectedOption == 1))
                        {
                            selectedOption --;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (!(selectedOption == _Options.Length))
                        {
                            selectedOption ++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        goToOption(selectedOption);
                        break;
                }

                // Draw the options again
                for (int i = 0; i < _Options.Length; i++)
                {
                    ConsoleFunctions.writeToCenter($"({i+1}) {_Options[i].ToString()}",4+i);
                }
            }
        }
        
        public void goToOption(int option)
        {
            if (selectedOption == 7)
            {
                isFinished = true;
            }
        }
    }
}