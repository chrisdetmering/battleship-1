namespace Battleship
{
    class Program
    {
 
        static void Main(string[] args)
        {
            Display display = new Display();
            BattleShip battleship = new BattleShip();

            Game game = new(battleship, display);

            game.Intro();
            game.Play();
            
        }
      
     }

}
