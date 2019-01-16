using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleCarsExcpeptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car(35);  // call constructor and set speed max to 35 (tiny engine!!)
            string ErrorMessage = "All is well";


            //PUT  try catches in while loop switch to catch throws from car class and to set ErrorMessage
            bool bHadError = false;  // to check if we had an error this loop
            bool done = false; // loop control variable
            while (!done)
            {
                bHadError = false;  // not really needed here...
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("start = start engine, stop = stop engine");
                Console.Write("accel = accelerate, brake = brake, q = quit. Command? :");
                Console.ResetColor();
                string userInput = Console.ReadLine();
                userInput = userInput.ToLower();  // in case user happened to enter capital letters
                Console.Clear();  // each time we get a new command, clear the prior history from the console

                try
                {

                    switch (userInput)
                    {
                        case "start":
                            myCar.StartEngine();
                            break;
                        case "stop":
                            myCar.StopEngine();
                            break;
                        case "accel":
                            myCar.Accelerate();
                            break;
                        case "brake":
                            myCar.Decelerate();
                            break;
                        case "q":
                        case "e":
                            Console.WriteLine("Goodbye");
                            done = true;
                            break;
                        default:
                            Console.WriteLine("Not a valid input.");
                            break;
                    }
                }// end try
                catch(ApplicationException ex)
                {
                    ErrorMessage = ex.Message;
                    bHadError = true;
                    // if one of ours, set the ErrorMessage to exceptions message,
                    // if not, then set ErrorMessage to "All is well" 
                }

               
                // at the end of each command, call this method to show status
                DisplayCarState(ErrorMessage, myCar);
                if (bHadError)  // reset error message now
                {
                    ErrorMessage = "All is well";
                    bHadError = false;
                }
            }
            Console.ReadLine();

        }

        private static void DisplayCarState(string msg, Car myCar)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(msg);
            Console.WriteLine("Engine is running: " + myCar.EngineRunning);
            Console.WriteLine("Current speed is: " + myCar.CurrentSpeedMPH);
            Console.ResetColor();
        }
    }
}
