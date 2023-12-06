using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFiller
{
    class Program
    {
        static void Main(string[] args)
        {
            Paint paint = new Paint(50, 30);
            paint.PutRandomNumbers(300);
            paint.Fill(20, 20);
            Console.ReadKey();
        }

        


    }
}
