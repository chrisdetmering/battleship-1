using System;
namespace Battleship
{
    public class Game
    {

        private static BattleShip _battleship;
        private static Display _display; 


        public Game(BattleShip battleship, Display display)
        {
            _battleship = battleship;
            _display = display; 
        }



        public void Intro()
        {
            string wantToPlay = "";
            string wantTutorial = "";

            while (wantToPlay != "y")
            {

                wantToPlay = _display.GetUserInput("Do you want to play? (y or n)");
                if (wantToPlay == "n")
                {
                    _display.GetUserInput("Then why are you here?");
                }
            }


            wantTutorial = _display.GetUserInput("Do you want a tutorial? (y or n)");
            if (wantTutorial == "y")
            {
                _display.Tutorial();
            }
            if (wantTutorial == "n")
            {
                _display.GetUserInput("You think you got what it takes, huh? Press any key and find out.");
            }
            Console.Clear();
        }



        public void Play()
        {
        
            _battleship.SetCoordinates();
            int ShotsLeft = 10;
            int[,] coordinatesHit = new int[5, 2];
            int[,] coordinatesMissed = new int[10, 2];
            string[,] coordinatesGrid = BaseGrid();
            int ShotsMissed = 0;
            int inputX = 0;
            int inputY = 0;

            while (ShotsLeft != 0)
            {
                try
                {
                    _display.ScoreBoard(ShotsLeft, _battleship.ReceivedHits, ShotsMissed);
                    

              
                    _display.Grid(coordinatesGrid);

                    Console.WriteLine("");

                    inputX = _display.GetCoordinate("(X - Axis) - Select a spot[1 - 10] to fire upon: ");
                    Console.WriteLine("");
                    inputY = _display.GetCoordinate("(Y - Axis) - Select a spot[1 - 10] to fire upon: ");
                    AlreadyAttempted(inputX, inputY, coordinatesHit, coordinatesMissed);
                }
                catch (FormatException)
                {

                    _display.Statement("Incorrect Input ensign! Numbers 1 - 10!!!! Press Enter to Resume!");
                    continue;
                }

                Console.WriteLine("");

                if (inputX > 10 || inputX < 1 || inputY > 10 || inputY < 1)
                {
                    _display.Statement("Incorrect Input ensign! Numbers 1 - 10!!!! Press Enter to Resume!");
                    continue;
                }

                if (AlreadyAttempted(inputX, inputY, coordinatesHit, coordinatesMissed))
                {

                    _display.Statement("Rookie mistake ensign! Choose a spot you haven't already shot at! Press Enter to resume!");
                    continue;
                }

                if (DidMissileHit(inputX, inputY, ShotsMissed, _battleship.Coordinates, coordinatesHit, coordinatesMissed))
                {
                    ShotsLeft--;
                    _battleship.ReceivedHits++;
                    if (_battleship.ReceivedHits == 5)
                    {

                        _display.Statement("Congratulations! You've won!");
                        break;
                    }
                    Console.WriteLine("Hit!");
                    coordinatesGrid[inputY - 1, inputX - 1] = " X ";
                }
                else
                {
                    ShotsLeft--;
                    ShotsMissed++;
                    Console.WriteLine("");
                    Console.WriteLine("Miss!");
                    coordinatesGrid[inputY - 1, inputX - 1] = " O ";
                }
                if (ShotsLeft - 1 == 0)
                {

                    _display.Statement("Game Over!");
                    break;
                }

                Console.WriteLine("");
                Console.WriteLine("Press Enter to resume!");
                inputX = 0;
                inputY = 0;
                Console.ReadLine();
                Console.Clear();
            }


        }

        static private bool AlreadyAttempted(int x, int y, int[,] hitArray, int[,] missedArray)
        {
            for (int i = 0; i < hitArray.GetLength(0); ++i)
            {
                if (hitArray[i, 0] == x && hitArray[i, 1] == y)
                {
                    return true;
                }
            }
            for (int i = 0; i < missedArray.GetLength(0); ++i)
            {
                if (missedArray[i, 0] == x && missedArray[i, 1] == y)
                {
                    return true;
                }
            }

            return false;
        }

        static private bool DidMissileHit(int x, int y, int shotsMissed, int[,] enemyArray, int[,] hitArray, int[,] missedArray)
        {
            for (int i = 0; i < enemyArray.GetLength(0); ++i)
            {
                if (enemyArray[i, 0] == x && enemyArray[i, 1] == y)
                {
                    hitArray[i, 0] = enemyArray[i, 0];
                    hitArray[i, 1] = enemyArray[i, 1];
                    return true;
                }
            }
            missedArray[shotsMissed, 0] = x;
            missedArray[shotsMissed, 1] = y;
            return false;
        }


        static private string[,] BaseGrid()
        {
            string[,] newGrid = new string[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    newGrid[i, j] = " - ";
                }
            }

            return newGrid;

        }



    }
}
