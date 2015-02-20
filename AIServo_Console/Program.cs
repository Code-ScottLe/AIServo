using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIServo.Engine;

namespace AIServo_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Exposure ex_1 = new Exposure("200", "2.8", "1/60");
            Exposure ex_2 = new Exposure("200", "2.8", "1/50");

            var result = ex_1 - ex_2;
            Console.WriteLine("The different in EV is : {0} * 1/3", result);

        }
    }
}
