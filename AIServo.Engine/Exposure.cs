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
    }
}
