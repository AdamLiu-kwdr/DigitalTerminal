using System;
using System.Threading;

using DigitalTerminal.Modules;

namespace DigitalTerminal.Pages
{
    //A class represents A menu screen
    public class MenuPage
    {
        private string _MenuTitle = "";
        private string _MenuSubTitle = "";

        private string[] _MenuOptions = {};

        private int selectedOption = 1;

        //Set to True for leaving menu
        bool isFinished = false;

        //Event for selecting an option (User press enter), int for index of selected option.
        public event EventHandler<int> OptionSelected;



        public MenuPage(string Title,string SubTitle,string[] MenuOptions){
            _MenuTitle = Title;
            _MenuSubTitle = SubTitle;
            _MenuOptions = MenuOptions;
        }

        //Show this menu to the screen
        public void Show()
        {
            InitScreen();
            //Remember current background/text color
            var currentBgColor = Console.BackgroundColor;
            var currentTxtColor = Console.ForegroundColor;
            
            //Keep in this menu until isFinished = true
            while (!isFinished)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                ConsoleFunctions.writeToCenter($"({selectedOption}) {_MenuOptions[selectedOption-1].ToString()}",4+selectedOption-1);
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
                        if (!(selectedOption == _MenuOptions.Length))
                        {
                            selectedOption ++;
                        }
                        break;

                    //Raise OptionSelected event with SelectedOption
                    case ConsoleKey.Enter:
                        OptionSelected.Invoke(this,selectedOption);
                        InitScreen(); //Reinit the screen after returning to this menu
                        break;
                    
                    //Exit Menu
                    case ConsoleKey.Backspace:
                        isFinished = true;
                        break;
                }
                //draw all Options again
                for (int i = 0; i < _MenuOptions.Length; i++)
                {
                    ConsoleFunctions.writeToCenter($"({i+1}) {_MenuOptions[i].ToString()}",4+i);
                }
            }
        }

        //Init Menu screen
        private void InitScreen(){
            //Draw blocks and menu properties
            
            Console.Clear();
            Console.WriteLine();
            ConsoleFunctions.drawRectangle(15,Console.BufferWidth-1,0,0);
            ConsoleFunctions.writeToCenter(_MenuTitle,1);
            ConsoleFunctions.writeToCenter(_MenuSubTitle,2);

            //Display all Options
            for (int i = 0; i < _MenuOptions.Length; i++)
            {
                Thread.Sleep(30);
                ConsoleFunctions.writeToCenter($"({i+1}) {_MenuOptions[i].ToString()}",4+i);
            }

            //Write instructions
            ConsoleFunctions.writeToCenter("[Up]:Previous      [Down]:Next      [Enter]:Select      [Backspace]:Exit",15);
        }
    }
}