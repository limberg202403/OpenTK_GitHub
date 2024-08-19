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

            game figure = new game("T", 1000, 1000);
            figure.Run();
            
        }
    }
}
