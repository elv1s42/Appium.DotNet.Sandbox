﻿using System;

namespace Appium.Net.Sandbox.Utils
{
    public static class ConsoleLogger
    {
        public static string Read()
        {
            return Console.ReadLine();
        }

        public static int ReadInt()
        {
            var res = Read() ?? "1";
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
            return number;
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void Write(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void Message(string msg)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("T")}]: {msg}");
        }

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
