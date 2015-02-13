using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIServo.Engine
{

    public class Exposure_Value
    {
        private string _value;

        public Exposure_Value()
        {
            throw new System.NotImplementedException();
        }


        public Exposure_Value OneThirdStep_Increment();

        public Exposure_Value OneThirdStep_Decrement();
    }
}
