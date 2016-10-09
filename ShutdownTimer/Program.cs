using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ShutdownTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            int seconds = Start();
            while(true)
            {
                int minutes = (int) (seconds / 60);
                Console.Clear();
                Console.WriteLine("Computer set to shutdown in {0} minutes and {1} seconds", minutes, seconds % 60);

                seconds--;
                if(seconds < 0)
                {
                    Shutdown();
                    break;
                } else if(seconds < 10)
                {
                    Console.Beep();
                }

                Thread.Sleep(1000);
                
            }

        }

        static int Start()
        {
            Console.WriteLine("Windows shutdown timer program by Jordan Campbell");
            Console.WriteLine("Please enter the amount of minutes you want until your pc will shut off");

            string input = Console.ReadLine();
            int x = 0;
            if (Int32.TryParse(input, out x))
            {
                return x * 60;
            } else
            {
                Console.Clear();
                Start();
            }
            return -1;
        }

        static void Shutdown()
        {
            Console.Clear();
            Console.WriteLine("Shutdown!");
            Process.Start("shutdown", "/s /t 0");
        }
    }
}
