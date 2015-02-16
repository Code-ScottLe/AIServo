using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIServo.Engine
{
    public class Aperture_Value : Exposure_Value
    {

        //Fields

        //Aperture range
        //Subject to be changed in the later build
        private static List<string> Aperture_Range = new List<string>() {"1.0","1.1","1.2","1.4","1.6","1.8","2.0","2.2","2.5","2.8",
            "3.2","3.5","4.0","4.5","5.0","5.6","6.3","7.1","8.0","9.0","10.0","11.0","13.0","14.0","16.0","18.0","20.0","22.0"};


        //Property(ies)
        public string Av
        {
            get
            {
                return _value;
            }

            set
            {
                //Warning: no checking logic.
                _value = value;
            }
        }

        
        //Constructor(s)

        public Aperture_Value()
        {
            //default constructor
            //defualt value for aperture is f/4.0 (or 4.0)
            _value = "4.0";
        }

        public Aperture_Value(string av)
        {
            //Overload Constructor
            //accept a string represent the aperture value
            Av = av;
        }

        public Aperture_Value(double av)
        {
            //Overload constructor
            //Accept a double represent the aperture value
            Av = av.ToString();
        }


        //Method(s)
        public override Exposure_Value OneThirdStep_Increment()
        {

            /*Override method
            * Increment the current value of Aperture to have +1/3 EV compare to old one*/

            //Back up the current value for return
            Aperture_Value old_value = new Aperture_Value(this.Av);

            //Get the current Aperture's index on the table
            int index = Aperture_Range.IndexOf(Av);

            //Check if it is the biggest aperture already
            //NOTE: The smaller the number, the bigger the aperture.
            if (index != 0)
            {
                //If that is the case, increment.
                Av = Aperture_Range[index - 1];
            }

            //return the old value
            return old_value;
        }

        public override Exposure_Value OneThirdStep_Decrement()
        {
            /*Override method
            * Increment the current value of Aperture to have -1/3 EV compare to old one*/

            //Back up the current value for return
            Aperture_Value old_value = new Aperture_Value(this.Av);

            //Get the current Aperture's index on the table
            int index = Aperture_Range.IndexOf(Av);

            //Check if it is the smallest aperture already
            //NOTE: The smaller the number, the bigger the aperture.
            if (index != (Aperture_Range.Count -1))
            {
                //If that is the case, increment.
                Av = Aperture_Range[index + 1];
            }

            //return the old value
            return old_value;
        }



        //Operators overloads
        public static Aperture_Value operator ++(Aperture_Value var)
        {
            //Default to increment 1/3EV to the current value
            var.OneThirdStep_Increment();

            return var;
        }

        public static Aperture_Value operator --(Aperture_Value var)
        {
            //default to decrement 1/3EV to the current value
            var.OneThirdStep_Decrement();

            return var;
        }

        public static int operator -(Aperture_Value var1, Aperture_Value var2)
        {
            /*Overload for oprator -
             * return the different in EV step in term of 1/3 step count between 2 value
             * */

            //get the index in the table for the first value
            int index_1 = Aperture_Range.IndexOf(var1.Av);

            //get the index in the table for the 2nd value
            int index_2 = Aperture_Range.IndexOf(var2.Av);

            //return the different
            //NOTE: because the Aperture table is built from big aperture to small aperture, the different on the table will have to be negated
            //for corrent value in EV difference
            return (-1) * (index_1 - index_2);
        }
    }
}
