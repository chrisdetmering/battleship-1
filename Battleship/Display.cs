using System;
namespace Battleship
{
    public class Display
    {
        public Display()
        {
        }


        public string GetUserInput(string question)
        {
            string userInput;
            Console.Clear();
            Console.WriteLine(question);
            userInput = Console.ReadLine();
            return userInput; 
        }

        public void Statement(string statement)
        {
            Console.Clear();
            Console.WriteLine(statement);
            Console.ReadLine();
            Console.Clear();
        }



        public void Tutorial()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine("");
            Console.WriteLine("The game is simple, you will be prompted to select a point on a 10 x 10 grid.");
            Console.WriteLine("The point is made up of X-value and a Y-value that represent on square of the grid ... Please see below");
            Console.WriteLine("");
            for (int i = 10; i > 0; i--)
            {
                if (i == 10)
                {
                    Console.WriteLine("{0}  - - - - - - - - - -", i);
                }
                else
                {
                    Console.WriteLine("{0}   - - - - - - - - - -", i);
                }

            }
            Console.WriteLine(" ");
            Console.WriteLine("0   1 2 3 4 5 6 7 8 9 10");
            Console.WriteLine("Once the point is selected you will be prompted with a hit or miss.");
            Console.WriteLine("You will be given a total of 10 guesses. If you do not destroy the nemy vessel...");
            Console.WriteLine("You are probably a fit for the 1588 spanish armada and lose the game.");
            Console.WriteLine("However if you annihalate the enemy which takes up 5 grid spaces you win!");
            Console.WriteLine("After which you can gloat to your friends and family and garner the respect of your peers");
            for (int i = 0; i < 50; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Press any key and lets fire up the boilers and ship off!");
            Console.ReadLine();
        }


        public void Grid(string[,] grid)
        {
            for (int a = grid.GetLength(0); a > 0; a--)
            {
                if (a == 10)
                {
                    Console.Write("{0}", a);
                }
                else
                {
                    Console.Write("{0} ", a);
                }
                {
                    for (int b = 0; b < 10; b++)
                    {
                        Console.Write("{0}", grid[a - 1, b]);
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("0  1  2  3  4  5  6  7  8  9  10");
        }

        public void ScoreBoard(int ShotsLeft, int Hits, int Misses)
        {
            Console.WriteLine("Shots Remaining = {0} | Hits = {1} | Misses = {2}", ShotsLeft, Hits, Misses);

            Console.WriteLine("");
        }

        public int GetCoordinate(string question)
        {
            Console.Write(question);
            return int.Parse(Console.ReadLine());

        }

    }
}
