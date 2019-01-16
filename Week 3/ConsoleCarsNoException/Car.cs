using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Car
    {
        // fields
        private decimal _CurrentSpeedMPH; // the cars current speed
        private decimal _MaxSpeedMPH;  // the upper limit, the car cannot exceed this value
        private bool _EngineRunning;  // true means the engine has been started and is running, false says engine is off

        public Car(decimal maxSpeed) // constuctor, user chooses to set maxSpeed as they create the object
        {
            _MaxSpeedMPH = maxSpeed;
            _CurrentSpeedMPH = 0;
            _EngineRunning = false;
        }

      
        public bool EngineRunning   // Property to allow reading the current value
        {   get   {   return _EngineRunning;   }   }

        public decimal CurrentSpeedMPH    // Property to allow reading the current value
        {   get   {   return _CurrentSpeedMPH;   }   }
     

    
        public void StartEngine()  // method used to start car's engine
        {
           if(_EngineRunning)
            {
                throw new ApplicationException("Starter Complains Loudly!  The engine is already running!");
            }
            _EngineRunning = true;
        }

        public void StopEngine()    // method used to stop car's engine
        {
            if (!_EngineRunning)
            {
                throw new ApplicationException("Nothing happens.... The engine is already off!");
            }
            _EngineRunning = false;
        }


        public void Accelerate()  // method used to increase the cars speed
        {
            if (!_EngineRunning)
            {
                throw new ApplicationException("You are disapointed by the absolute lack of accelleration. The engine is Off!");
            }
            else
            {
                _CurrentSpeedMPH = _CurrentSpeedMPH + 10;  // this method always tries to increase by 10 mph
                if (_CurrentSpeedMPH > _MaxSpeedMPH)  // but it can never exceed the max speed as set in the constructor
                {
                    _CurrentSpeedMPH = _MaxSpeedMPH;  // if speed is higher than max, slow it to max
                }
            }
        }

        public void Decelerate()  // this method always tries to decrease the speed by 5 mph
        {
            _CurrentSpeedMPH = _CurrentSpeedMPH - 5;  // but never lets it go below 0 and become negative.
            if (_CurrentSpeedMPH < 0)
            {
                _CurrentSpeedMPH = 0;
            }
        }

       
    }
}
