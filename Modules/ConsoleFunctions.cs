using System;

namespace DigitalTerminal.Modules
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
            for (int i = StartX+1; i <= StartX+Width-1; i++)
            {
                writeTO("-",i,StartY);
            }
            writeTO("+",StartX+Width-1,StartY);

            //draw leftside
            //i <= (Start Location)+(Height normalized, start from 0)-(Reserve corner for "+")
            for (int i = StartY+1; i <= StartY+Height-1-1; i++) 
            {
                writeTO("|",StartX,i);
            }
            
            //draw underside
            writeTO("+",StartX,StartY+Height-1);
            for (int i = StartX+1; i <= StartX+Width-1; i++)
            {
                writeTO("-",i,StartY+Height-1);
            }
            writeTO("+",StartX+Width-1,StartY+Height-1);

            //draw rightside
            //i <= (Start Location)+(Height normalized, start from 0)-(Reserve corner for "+")
            for (int i = StartY+1; i <= StartY+Height-1-1; i++)
            {
                writeTO("|",StartX+Width-1,i);
            }
        }
    }
}