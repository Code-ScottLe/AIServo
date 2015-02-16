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
            ISO_Value iso = new ISO_Value(200);

            ShutterSpeed_Value shutter = new ShutterSpeed_Value("1/40");

            Aperture_Value aperture = new Aperture_Value(2.2);

            //Later

            ISO_Value a_iso = new ISO_Value(1600);

            ShutterSpeed_Value a_shutter = new ShutterSpeed_Value("1/2");

            Aperture_Value a_aperture = new Aperture_Value(1.4);


            Console.WriteLine("ISO Diff: {0}\nShutter Diff: {1}\nAperture Diff: {2}", a_iso - iso, a_shutter - shutter, aperture - a_aperture);


        }
    }
}
