using System;

namespace CyberArtDemo.Interface
{
    //For drawing shapes/ writing text to certain position.
    public static class ConsoleFunctions
    {

        public static void writeTO(string input,int CordX,int CordY)
        {
            try
            {
                Console.SetCursorPosition(CordX,CordY);
                Console.Write(input);
            }
            catch (System.Exception e)
            {
                Console.Clear();
                Console.Write(e.Message);
            }
        }

        //set CordY to desired row.
        public static void writeToCenter(string input,int CordY)
        {
            writeTO(input,(Console.BufferWidth-input.Length)/2-1,CordY);
        }

        //Draws a rectangle 
        public static void drawRectangle(int Height,int Width,int StartX,int StartY)
        {
            //draw topside
            writeTO("+",StartX,StartY);
            for (int i = 1; i <= Width-1; i++)
            {
                writeTO("-",i,StartY);
            }
            writeTO("+",Width-1,StartY);

            //draw leftside
            for (int i = 1; i <= Height-2; i++) //Height-2 because "+" was draw by last line
            {
                writeTO("|",StartX,i);
            }
            
            //draw underside
            writeTO("+",StartX,Height-1);
            for (int i = 1; i <= Width-1; i++)
            {
                writeTO("-",i,Height-1);
            }
            writeTO("+",Width-1,Height-1);

            //draw rightside
            for (int i = 1; i <= Height-2; i++)
            {
                writeTO("|",Width-1,i);
            }
        }
    }
}