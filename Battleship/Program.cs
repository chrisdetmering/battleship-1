using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Intro();
            Console.Clear();
            Console.WriteLine("Do you want a tutorial? (y or n)");
            showTutorial(Console.ReadLine());*/
            //Game();
            GenerateGrid();
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
                for (int i = 0; i < 50; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
                Console.WriteLine("The Game is simple, you will be prompted to select a point ona  10 x 10 grid.");
                Console.WriteLine("The point is made up of X-value and a Y-value that represent on square of the grid ... Please see below");
                GenerateGrid();
                Console.WriteLine("Once the point is selected you will be prompted with a hit or miss.");
                Console.WriteLine("You will be given a total of 8 guesses. If you do not destroy the nemy vessel...");
                Console.WriteLine("You are probably a fit for the 1588 spanish armada and lose the game.");
                Console.WriteLine("However if you annihalate the enemy which takes up 5 grid spaces you win!");
                Console.WriteLine("After which you can gloat to your friends and family and garner the respect of your peers");
                for (int i = 0; i < 50; i++)
                {
                    Console.Write("*");
                }

            }
        }
        static void Game()
        {
            int Remaining = 8;
            int Hits = 0;
            int Misses = 0;
            int inputX = 0;
            int inputY = 0;


            Console.WriteLine("Shots Remaining = {0} | Hits = {1} | Misses = {2}", Remaining, Hits, Misses);

            GenerateGrid();
            Console.WriteLine("");

            Console.Write("(X-Axis) - Select a spot [1-10] to fire upon : ");
            inputX = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("(Y-Axis) - Select a spot [1-10] to fire upon : ");
            inputY = int.Parse(Console.ReadLine());
        }
        static void GenerateGrid()
        {
            for (int i = 10; i > 0; i--)
            {
                if(i == 10)
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
        }
        static void CreateEnemyShip()
        {
            int[,] enemyShip = new int[5, 2];
            int firstX = GiveMeANumber();
            int firstY = GiveMeANumber();
            bool moveX = trueOrFalse();

            if(moveX == true)
            {
                if(firstX > 5)
                {
                    for(int i = 0; i < 5; i++)
                    {
                        enemyShip[i, 0] = firstX - i;
                        enemyShip[i, 1] = firstY;
                    }
                }
                if(firstX < 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        enemyShip[i, 0] = firstX + i;
                        enemyShip[i, 1] = firstY;
                    }
                }
            }
            else
            {
                if (firstY > 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        enemyShip[i, 0] = firstX;
                        enemyShip[i, 1] = firstY - i;
                    }
                }
                if (firstY < 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        enemyShip[i, 0] = firstX;
                        enemyShip[i, 1] = firstY+i;
                    }
                }
            }
        }
        static int GiveMeANumber()
        {
            int[] validNumbers = new int[] { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            Random rnd = new Random();
            return validNumbers[rnd.Next(1, validNumbers.Length + 1)];

        }
        private static bool trueOrFalse()
        {
            Random rnd = new Random();
            if(rnd.Next(1,3) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
