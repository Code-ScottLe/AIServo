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
        private System.Collections.Generic.List<string> ISO_Range = new List<string>() { "50", "64", "80","100","125","160","200","250","320","400",
            "500","640","800","1000","1250","1600","2000","2500","3200","4000","5000","6400","8000","10000","12800","16000",
            "20000","25600","32000","40000","51200","64000","80000","102400"};


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
            return null;
        }

        public override Exposure_Value OneThirdStep_Decrement()
        {
            return null;
        }


        //Operator Overload
        public static ISO_Value operator ++(ISO_Value var)
        {

        }


        public static ISO_Value operator --(ISO_Value var)
        {

        }

        public static ISO_Value operator -(ISO_Value var1, ISO_Value var2)
        {

        }
    }
}
