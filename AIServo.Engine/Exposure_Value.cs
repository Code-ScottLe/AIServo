using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIServo.Engine
{

    public class Exposure_Value
    {
        //Field(s)
        protected string _value;

        //Constructor(s)
        public Exposure_Value()
        {
            //Default Constructor
        }


        //Method(s)
        public abstract Exposure_Value OneThirdStep_Increment();

        public abstract Exposure_Value OneThirdStep_Decrement();
    }
}
