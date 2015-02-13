using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PCLStorage;
using System.Threading.Tasks;
using System.Windows;

namespace AIServo.Engine
{
    public class ShutterSpeed_Value : Exposure_Value
    {
        //Represent ShutterSpeed value in an Exposure of an picture. 
        //Field(s)

        /*set up the ShutterSpeed_Range.
        Limitation: This is hard-coded, please switch to reading from files in the future if possible.
         * */
       
        private static List<string> ShutterSpeed_Range = new List<string>()
            {
                "1/8000", "1/6400", "1/5000", "1/4000", "1/3200", "1/2500", "1/2000", "1/1600"
                ,"1/1250", "1/1000", "1/800", "1/640", "1/500", "1/400", "1/320", "1/250", "1/200"
                , "1/160", "1/125", "1/100", "1/80", "1/60", "1/50", "1/40", "1/30", "1/25", "1/20"
                , "1/15", "1/13", "1/10", "1/8", "1/6", "1/5", "1/4", "1/3", "1/2.5", "1/2", "1/1.6",
                "1/1.3", "1.0", "1.3", "1.6", "2.0", "2.5", "3.2", "4", "5", "6", "8", "10", "13", "15",
                "20", "25", "30"
            };
        //See why we have to remove this limitation in the future?

        //Constructor(s)
        public ShutterSpeed_Value()
        {
            /*Default constructor
            Default shutter speed is 1/50;
             * */
            Tv = "1/50";
            
        }

        public ShutterSpeed_Value(string shutter_speed)
        {
            /*2nd Construtor (overloaded)
            Accept a string shutter_speed, which represent a shutter speed of the setting in string
             * */
            Tv = shutter_speed;
            
        }


        //Property(s)
        public string Tv
        {
            get
            {
                return _value;
            }

            set
            {
                //warning: did not check correct Shutter Speed
                _value = value;
            }
        }

        //Method(s)
        
        //Base class method(s) override
        public override Exposure_Value OneThirdStep_Increment()
        {
            //Override in ShutterSpeed_Value
            //Adjust the value for 1/3 step increment.

            //First, create a clone of the current value
            ShutterSpeed_Value old_value = new ShutterSpeed_Value(this.Tv);

            //Second, find the current shutter speed in the shutter range
            int index = ShutterSpeed_Range.IndexOf(this.Tv);

            //If the ISO is not the highest one in the range, we increment it
            if(index != ShutterSpeed_Range.Count -1)
            {
                //Once we get the index, get the index +1 value, which indicate the shutter speed that will give +1/3 EV to the current EV Value
                Tv = ShutterSpeed_Range[index + 1];
            }
            
            //return the old value
            return old_value;
        }

        public override Exposure_Value OneThirdStep_Decrement()
        {
            //Override in ShutterSpeed_Value
            //Adjust the value for 1/3 stop decrement.
            //Override in ShutterSpeed_Value
            //Adjust the value for 1/3 step increment.

            //First, create a clone of the current value
            ShutterSpeed_Value old_value = new ShutterSpeed_Value(this.Tv);

            //Second, find the current shutter speed in the shutter range
            int index = ShutterSpeed_Range.IndexOf(this.Tv);

            //if the ISO is not the lowest one in the range, we decrement it
            if(index != 0)
            {
                //Once we get the index, get the index -1 value, which indicate the shutter speed that will give +1/3 EV to the current EV Value
                Tv = ShutterSpeed_Range[index - 1];
            }

            // return the old value
            return old_value;
        }

        public static ShutterSpeed_Value operator ++(ShutterSpeed_Value var)
        {
            var.OneThirdStep_Increment();
            return var as ShutterSpeed_Value;
        }

        public static ShutterSpeed_Value operator --(ShutterSpeed_Value var)
        {
            var.OneThirdStep_Decrement();
            return var as ShutterSpeed_Value;
        }

        public static int operator -(ShutterSpeed_Value var1, ShutterSpeed_Value var2)
        {
            //return the number of 1/3 step different between 2 shutter value

            //look up the shutter speed in the table.
            int index_var1 = ShutterSpeed_Range.IndexOf(var1.Tv);
            int index_var2 = ShutterSpeed_Range.IndexOf(var2.Tv);

            return index_var1 - index_var2;
        }
    }
}
