using System;
using System.Threading;
namespace CyberArtDemo.Interface
{
    //A class represents A menu screen
    public class UIMenu
    {
        private string _MenuTitle = "";
        private string _MenuSubTitle = "";

        private string[] _Options = {};

        //Properties
        public string getTitle { get{return _MenuTitle;}}
        public string getSubTitle { get{return _MenuSubTitle;}}
        public string[] GetOptions {get{return _Options;}}

        public UIMenu(string Title,string SubTitle,string[] Options){
            _MenuTitle = Title;
            _MenuSubTitle = SubTitle;
            _Options = Options;
        }

        //Show this menu to the screen
        public void Goto()
        {
            Console.Clear();
            Console.WriteLine();
            ConsoleFunctions.drawRectangle(15,Console.BufferWidth-1,0,0);
            ConsoleFunctions.writeToCenter(_MenuTitle,1);
            ConsoleFunctions.writeToCenter(_MenuSubTitle,2);

            for (int i = 0; i < _Options.Length; i++) //Display all Options
            {
                Thread.Sleep(30);
                ConsoleFunctions.writeToCenter($"({i+1}) {_Options[i].ToString()}",4+i);
            }
            
            Thread.Sleep(60);
             ConsoleFunctions.writeToCenter("Please select:",13);
            Console.ReadLine();
            //Remember to draw the previous Menu again when returning to caller!
        }

        
    }
}