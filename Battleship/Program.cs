using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            //Intro();
            Game();
        }
        static void Intro()
        {
            string wantToPlay = "";
            string wantTutorial = "";

            while (wantToPlay != "y")
            {
                Console.WriteLine("Do you want to play? (y or n)");
                wantToPlay = Console.ReadLine();
                if (wantToPlay == "n")
                {
                    Console.WriteLine("Then why are you here?");
                }
            }

            Console.Clear();
            Console.WriteLine("Do you want a tutorial? (y or n)");
            wantTutorial = Console.ReadLine();
            if(wantTutorial == "y")
            {
                ShowTutorial();                
            }
            Console.Clear();
        }
        static void ShowTutorial(){
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
        static void Game()
        {
            var EnemyShip = new Battleship();
            EnemyShip.SetCoordinates();

            int ShotsLeft = 10;
            int ShotsMissed = 0;
            int inputX = 0;
            int inputY = 0;


            while (ShotsLeft > 0 || EnemyShip.ReceivedHits < 5)
            {
                try
                {

                    Console.WriteLine("Shots Remaining = {0} | Hits = {1} | Misses = {2}", ShotsLeft, EnemyShip.ReceivedHits, ShotsMissed);
                    Console.WriteLine("");
                    foreach (var i in EnemyShip.Coordinates)
                    {
                        Console.Write("{0} ", i);
                    }
                    Console.WriteLine("");

                    GenerateGrid();
                    Console.WriteLine("");

                    inputX = Util.AskInt("(X - Axis) - Select a spot[1 - 10] to fire upon: ");
                    Console.WriteLine("");
                    inputY = Util.AskInt("(Y - Axis) - Select a spot[1 - 10] to fire upon: ");
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect Input ensign! Numbers 1 - 10!!!! Press Enter to Resume!");
                    Console.ReadLine();
                    Console.Clear();
                }

                //var madeContact = DidMissileHit(inputX, inputY, EnemyShip.Coordinates);

                Console.WriteLine("");
                Console.WriteLine("{0}", DidMissileHit(inputX, inputY, EnemyShip.Coordinates));

                Console.ReadLine();
                ShotsLeft--;


                //1)how to compare inputs with enemy ship

                //2)how to compare inputs with previous attempts

                //if inputs already attempted
                    //Console.WriteLine("")
                    //Console.WriteLine("Rookie mistake ensign! Choose a post you haven't already shot at! Press Enter to resume!");
                    //Console.Readline();
                    //go back to game, no penalty (NEED TO FIGURE OUT).

                //if inputs don't match enemyship
                    //Remaining--;
                    //Misses++;
                    //Console.WriteLine("");
                    //Console.WriteLine("Miss!");
                    //Console.WriteLine("");
                    //Console.WriteLine("Press Enter to resume!");
                    //Figure out a way to update the grid (NEED TO DO)
                    //Console.Readline();


                //if inputs do match enemy ship
                    //Remaining--
                    //Hits++
                    //


            }

        }
        /*Console.WriteLine("");
        foreach (var i in EnemyShip.Coordinates)
        {
            Console.Write("{0} ", i);
        }
        Console.WriteLine("");
        for (int i = 0; i < EnemyShip.Coordinates.Length; i++)
        {
            Console.WriteLine("{0}", EnemyShip.Coordinates[i, 0]);
        }*/
        static public bool DidMissileHit(int x, int y, int[,] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i, 0] == x && array[i,1] ==y)
                {
                    return true;
                }
            }
            return false;

        }
        class Battleship
        {
            public int ReceivedHits = 0;
            public int[,] Coordinates = new int[5, 2];
            public void SetCoordinates()
            {
                int firstX = GiveMeANumber();
                int firstY = GiveMeANumber();
                bool moveX = RandomTrueOrFalse();

                if (moveX == true)
                {
                    if (firstX > 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Coordinates[i, 0] = firstX - i;
                            Coordinates[i, 1] = firstY;
                        }
                    }
                    if (firstX < 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Coordinates[i, 0] = firstX + i;
                            Coordinates[i, 1] = firstY;
                        }
                    }
                }
                else
                {
                    if (firstY > 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Coordinates[i, 0] = firstX;
                            Coordinates[i, 1] = firstY - i;
                        }
                    }
                    if (firstY < 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Coordinates[i, 0] = firstX;
                            Coordinates[i, 1] = firstY + i;
                        }
                    }
                }
            }
            static public int GiveMeANumber()
            {
                int[] validNumbers = new int[] { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
                Random rnd = new();
                return validNumbers[rnd.Next(1, validNumbers.Length + 1)];

            }
            static public bool RandomTrueOrFalse()
            {
                Random rnd = new();
                if (rnd.Next(1, 3) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        static void GenerateGrid()
        {
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
        }


    }

}
