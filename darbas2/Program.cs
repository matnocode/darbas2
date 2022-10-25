using System;

namespace darbas2
{
    internal class Program
    {
        public static readonly int offsetX = 5;
        static float GetNumberInput(string revaluation)
        {
            float val = 0;
            try
            {

                val = float.Parse(Console.ReadLine());
                if (val > Console.LargestWindowWidth / 2 - offsetX)
                    throw new Exception();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Prasau iveskite skaiciu. (Maximalus aukstis - {Console.LargestWindowWidth / 2 - offsetX}):");
                Console.WriteLine(revaluation);
                val = GetNumberInput(revaluation);
            }
            return val;
        }
        static void RenderTree(string symbol, int heigth)
        {
            if (heigth < Console.LargestWindowWidth / 2 - offsetX)
            {
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            }
            Console.Clear();
            int tempX = 0;
            for (int y = 0; y < heigth; y++)
            {
                Console.ResetColor();          
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition((Console.WindowWidth / 2) + tempX, y);
                Console.Write(symbol);
                for (int left = 0; left < tempX; left++)
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - tempX, y);
                    Console.Write(symbol);
                }
                
                if (y < heigth / 2)               
                    tempX++;               
                else               
                    tempX--;
                
            }
        }
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("Rombo sudarymas.");
            Console.Write("Iveskite Rombo auksti: ");
            int treeH = (int)GetNumberInput("Iveskite Rombo auksti: ");
            RenderTree("*", treeH);
            Console.ReadLine();
        }
    }
}
