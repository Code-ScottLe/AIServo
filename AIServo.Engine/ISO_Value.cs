using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIServo.Engine
{
    public class ISO_Value : Exposure_Value
    {
        //Fields

        //ISO Range Table.
        //Subject to be changed in later build. 
        private static System.Collections.Generic.List<string> ISO_Range = new List<string>() { "50", "64", "80","100","125","160","200","250","320","400",
            "500","640","800","1000","1250","1600","2000","2500","3200","4000","5000","6400","8000","10000","12800","16000",
            "20000","25600","32000","40000","51200","64000","80000","102400"};

        //Property(ies)
        public string ISO
        {
            get
            {
                return _value;
            }

            set
            {
                //note : no logic check.
                _value = value;
            }
        }


        //Constructor
        public ISO_Value()
        {
            //default constructor
            //default value for ISO is 100
            _value = "100";
        }

        public ISO_Value(int iso)
        {
            /*
             * 2nd Constructor, accepet an ISO value as interger
             * */

            _value = iso.ToString();
        }

        public ISO_Value(string iso)
        {
            /*3rd constructor, accept an ISO value as string
             * */
            _value = iso;
        }


        //Method(s)
        public override Exposure_Value OneThirdStep_Increment()
        {
           /*Override method
            * Increment the current value of ISO to have +1/3 EV compare to old one*/

            //Back up the current value for return
            ISO_Value old_value = new ISO_Value(this.ISO);
            
            //Get the current ISO's index on the table
            int index = ISO_Range.IndexOf(ISO);

            //Check if it is the higheset ISO already
            if (index != (ISO_Range.Count -1))
            {
                //If that is the case, increment.
                ISO = ISO_Range[index + 1];
            }

            //return the old value
            return old_value;
        }

        public override Exposure_Value OneThirdStep_Decrement()
        {
            /*Override method
           * Increment the current value of ISO to have -1/3 EV compare to old one*/

            //Back up the current value for return
            ISO_Value old_value = new ISO_Value(this.ISO);

            //Get the current ISO's index on the table
            int index = ISO_Range.IndexOf(ISO);

            //Check if it is the lowest ISO already
            if (index != 0)
            {
                //If that is the case, decrement.
                ISO = ISO_Range[index - 1];
            }

            //return the old value
            return old_value;
        }


        //Operator Overload
        public static ISO_Value operator ++(ISO_Value var)
        {
            //Default to be +1/3EV
            //Call the instance 1/3 Step Increment
            var.OneThirdStep_Increment();

            //return itself
            return var;
        }


        public static ISO_Value operator --(ISO_Value var)
        {
            //Default to be -1/3EV
            //Call the instance 1/3 Step Decrement
            var.OneThirdStep_Decrement();

            //return itself
            return var;
        }

        public static int operator -(ISO_Value var1, ISO_Value var2)
        {
            /*Overload for oprator -
             * return the different in EV step in term of 1/3 step count between 2 value
             * */

            //get the index in the table for the first value
            int index_1 = ISO_Range.IndexOf(var1.ISO);

            //get the index in the table for the 2nd value
            int index_2 = ISO_Range.IndexOf(var2.ISO);

            //return the different
            return index_1 - index_2;
        }
    }
}
