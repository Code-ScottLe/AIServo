using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIServo.Engine
{
    public class Aperture_Value : Exposure_Value
    {
        private List<string> Aperture_Range;


        //Method(s)
        public override Exposure_Value OneThirdStep_Increment()
        {
            return null;
        }

        public override Exposure_Value OneThirdStep_Decrement()
        {
            return null;
        }
    }
}
