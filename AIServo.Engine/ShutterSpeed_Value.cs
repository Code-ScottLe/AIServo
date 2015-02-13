using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PCLStorage;
using System.Threading.Tasks;

namespace AIServo.Engine
{
    public class ShutterSpeed_Value : Exposure_Value
    {
        //Represent ShutterSpeed value in an Exposure of an picture. 
        //Field(s)
        private List<string> ShutterSpeed_Range;

        //Constructor(s)
        public ShutterSpeed_Value()
        {
            //Default constructor
            
            //set up the ShutterSpeed_Range.
            
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
                _value = value;
            }
        }

        //Method(s)
        
        //Base class method(s)
        public override ShutterSpeed_Value OneThirdStep_Increment()
        {
            //Override in ShutterSpeed_Value
            //Adjust the value for 1/3 step increment.
        }

        public override ShutterSpeed_Value OneThirdStep_Decrement()
        {
            
        }
    }
}
