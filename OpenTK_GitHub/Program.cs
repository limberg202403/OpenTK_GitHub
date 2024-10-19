using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_GitHub
{
    class Program
    {
        static void Main(string[] args)
        {
            using (game game = new game(800, 600, "LetraT"))
            {
                game.Run(60.0);
            }
        }
    }
}
