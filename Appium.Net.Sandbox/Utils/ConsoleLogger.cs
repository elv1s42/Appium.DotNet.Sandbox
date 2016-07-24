using System;

namespace Appium.Net.Sandbox.Utils
{
    public static class ConsoleLogger
    {
        public static void Start(string msg)
        {
            Console.Write($"[{DateTime.Now.ToString("T")}]: {msg}");
        }

        public static void Finish(string msg)
        {
            Console.WriteLine($"{msg} [{DateTime.Now.ToString("T")}]");
        }
    }
}
