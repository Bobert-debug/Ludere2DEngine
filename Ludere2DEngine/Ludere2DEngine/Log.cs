using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludere2DEngine.Ludere2DEngine
{
    class Log
    {
        //////////////////////////
        ////Custom Log System/////
        //////////////////////////
        
        //// Send Information Text(string, int, float, char, double, decimal or booleans) ////
        public static void Send(string text) 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[INFO] " + text);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public static void Send(int text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[INFO] " + text);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public static void Send(float text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[INFO] " + text);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public static void Send(char text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[INFO] " + text);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public static void Send(bool text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[INFO] " + text);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public static void Send(double text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[INFO] " + text);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public static void Send(decimal text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[INFO] " + text);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        //// Send Warning Text(string, int, float, char, double, decimal or booleans) ////
        public static void Warn(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARN] " + text);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }       
        public static void Warn(int text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARN] " + text);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void Warn(float text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARN] " + text);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void Warn(char text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARN] " + text);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void Warn(double text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARN] " + text);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void Warn(decimal text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARN] " + text);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void Warn(bool text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARN] " + text);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
       
        //// Send Error Text(string, int, float, char, double, decimal or booleans) ////
        public static void Error(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] " + text);
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public static void Error(int text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] " + text);
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public static void Error(float text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] " + text);
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public static void Error(char text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] " + text);
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public static void Error(double text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] " + text);
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public static void Error(decimal text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] " + text);
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public static void Error(bool text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] " + text);
            Console.ForegroundColor = ConsoleColor.Red;
        }

    }
}
