using System;
using static Appium.Net.Sandbox.Utils.ConsoleLogger;

namespace Appium.Net.Sandbox
{
    public class Program
    {
        public static void Main()
        {
            const string yes = "y";
            var flag = yes;
            while (flag.Equals("y"))
            {
                Clear();
                Write("Enter number to udpate:");
                var res = Get() ?? "1";
                int number;
                try
                {
                    number = int.Parse(res);
                }
                catch (Exception)
                {
                    Write("You've entered some shit, taking number = 1");
                    number = 1;
                }
                for (var i = 0; i < number; i++)
                {
                    var row = 1 + i/3;
                    var column = 1 + i%3;
                    MainRunner.ResetAllHashs(row, column);
                }
                Write("Continue ? (y/n)");
                flag = Get() ?? yes;
                if (!flag.Equals("n") && !flag.Equals("N"))
                {
                    flag = yes;
                }
            }
        }
    }
}