using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIServo.Engine
{
    public class Exposure
    {

        //Field(s)
        private ISO_Value _iso;
        private Aperture_Value _aperture;
        private ShutterSpeed_Value _shutter_speed;


        //Properties
        public ISO_Value ISO
        {
            get
            {
                return _iso;
            }

            set
            {
                _iso = value;
            }
        }

        public Aperture_Value Aperture
        {
            get
            {
                return _aperture;
            }

            set
            {
                _aperture = value;
            }
        }

        public ShutterSpeed_Value Shutter_Speed
        {
            get
            {
                return _shutter_speed;
            }

            set
            {
                _shutter_speed = value;
            }
        }
    

        //Contructor(s)
        public Exposure()
        {
            //default constructor
            _iso = new ISO_Value();
            _aperture = new Aperture_Value();
            _shutter_speed = new ShutterSpeed_Value();
        }

        public Exposure(string iso_value, string aperture_value, string shutterspeed_value)
        {
            //Overload constructor
            //Accept a string represent ISO value, a string represent aperture value and a string represent shutter speed value
            _iso = new ISO_Value(iso_value);
            _aperture = new Aperture_Value(aperture_value);
            _shutter_speed = new ShutterSpeed_Value(shutterspeed_value);
         
        }


        //methods


        //OP overload

        public static int operator-(Exposure var1, Exposure var2)
        {
            //return the different in number of 1/3 steps
            //Multiply with 1/3 for correct exposure difference.
            int iso_diff = var1.ISO - var2.ISO;
            int av_diff = var1.Aperture - var2.Aperture;
            int tv_diff = var1.Shutter_Speed - var2.Shutter_Speed;

            return iso_diff + av_diff + tv_diff;
        }
    
    }
}
