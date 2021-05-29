using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Intro();
            Console.Clear();
            Console.WriteLine("Do you want a tutorial? (y or n)");
            showTutorial(Console.ReadLine());
        }
        static void Intro()
        {
            string wantToPlay = "";

            while (wantToPlay != "y")
            {
                Console.WriteLine("Do you want to play? (y or n)");
                wantToPlay = Console.ReadLine();
                if (wantToPlay == "n")
                {
                    Console.WriteLine("Then why are you here?");
                }
            }
        }
        static void showTutorial(string answer){
            if (answer == "y")
            {
                Console.Clear();
                Console.WriteLine("*");
                for (int i = 0; i < 49; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("The Game is simple, you will be prompted to select a point ona  10 x 10 grid.");
                Console.WriteLine("The point is made up of X-value and a Y-value that represent on square of the grid ... Please see below");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("{0} - - - - - - - - - -", i);
                }
                Console.WriteLine("0 1 2 3 4 5 6 7 8 9 10");
                Console.WriteLine("Once the point is selected you will be prompted with a hit or miss.");
                Console.WriteLine("You will be given a total of 8 guesses. If you do not destroy the nemy vessel...");
                Console.WriteLine("You are probably a fit for the 1588 spanish armada and lsoe the game.");
                Console.WriteLine("However if you annihalate the enemy which takes up 5 grid spaces you win!");
                Console.WriteLine("After which you can gloat to your friends and family and garner the respect of your peers");
                for (int i = 0; i < 50; i++)
                {
                    Console.Write("*");
                }

            }
        }

    }
}
