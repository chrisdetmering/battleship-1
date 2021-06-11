using System;
namespace Battleship
{
    public class BattleShip
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
            return validNumbers[rnd.Next(1, validNumbers.Length)];

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
    
}
