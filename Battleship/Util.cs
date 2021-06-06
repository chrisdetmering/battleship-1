using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Util
    {
        static public int AskInt(string question)
        {
            System.Console.Write(question);
            return int.Parse(System.Console.ReadLine());

        }

    }

}
