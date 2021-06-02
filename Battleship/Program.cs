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
            showTutorial(Console.ReadLine());
            Console.Clear();*/
            Game();
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
                Console.WriteLine(" ");
                Console.WriteLine("Press any key and lets fire up the boilers and ship off!");
                Console.ReadLine();
            }
        }
        static void Game()
        {
            int remaining = 8;
            int hits = 0;
            int misses = 0;
            int inputX;
            int inputY;
            int[,] attemptedCoordinates = new int[8, 2];
            int[,] failedCoordinates = new int[8, 2];
            int[,] successfulCoordinates = new int[5, 2];
            int [,] targetShip = CreateEnemyShip();

            while (remaining != 0 || hits < 5)
            {
                Console.WriteLine("Shots Remaining = {0} | Hits = {1} | Misses = {2}", remaining, hits, misses);
                Console.WriteLine("");

                GenerateGrid();
                Console.WriteLine("");

                Console.Write("(X-Axis) - Select a spot [1-10] to fire upon : ");

                if(int.TryParse(Console.ReadLine(), out inputX)){
                    if( inputX < 11 && inputX > 0)
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        InvalidInputMessage();
                    }
                }

                Console.Write("(Y-Axis) - Select a spot [1-10] to fire upon : ");
                if (int.TryParse(Console.ReadLine(), out inputY))
                {
                    if (inputY < 11 && inputY > 0)
                    {
                        Console.WriteLine(inputY);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("that's not a valid entry!");
                    }

                }
                //check [inputX, inputY] are valid numbers
                //if [inputX, inputY] previously tried
                //go back to selecting values
                //if [x,y] match piece of ship
                //hits++
                //remaining--
                //push [x,y] to "already tried" variable
                //reset inputX and inputY to 0
                //prepare rerender of grid to mark hit
                // clear console.
                //rerender console.
                //if [x,y] does not match piece of ship
                //misses++
                //remaining--
                //push [x,y] to "already tried variable"
                //reset inputX and inputY to 0
                //prepare rerender of grid to mark miss
                //clear console
                //rerender console
                remaining--;
            }

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
        static void InvalidInputMessage()
        {
            Console.Clear();
            Console.WriteLine("Incorrect Input ensign! Numbers from 1 - 10!!!! Press Enter to resume");
            Console.ReadLine();

        }
        static void recursiveReturn(int remaining, int hits, int misses, int inputX, int inputY)
        {
            Console.WriteLine("Shots Remaining = {0} | Hits = {1} | Misses = {2}", remaining, hits, misses);
                Console.WriteLine("");

                GenerateGrid();
                Console.WriteLine("");

                Console.Write("(X-Axis) - Select a spot [1-10] to fire upon : ");
        }
        static int[,] CreateEnemyShip()
        {
            int[,] enemyShip = new int[5, 2];
            int firstX = GiveMeANumber();
            int firstY = GiveMeANumber();
            bool moveX = randomTrueOrFalse();

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
            return enemyShip;
        }
        static int GiveMeANumber()
        {
            int[] validNumbers = new int[] { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            Random rnd = new Random();
            return validNumbers[rnd.Next(1, validNumbers.Length + 1)];

        }
        private static bool randomTrueOrFalse()
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


       /* private static bool alreadyTried(int x, int y, int shotsLeft, int[,] array)
        {

        }*/
    }

}
/*foreach (int i in attemptedCoordinates)
{
    System.Console.Write("{0} ", i);
}*/