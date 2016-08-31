using System;
using System.Linq;
using static Appium.Net.Sandbox.Utils.ConsoleLogger;

namespace Appium.Net.Sandbox
{
    public class Program
    {
        private static void ValidateData()
        {
            if (Properties.App.Default.Hashs.Count != Properties.App.Default.Total 
                || Properties.App.Default.IdsToUpdate.Split(',').Length > Properties.App.Default.Total)
            {
                throw new Exception("Wrong data!");
            }
        }

        private static void SimpleResetHashs()
        {
            Write("Enter number to udpate:");
            var number = ReadInt();
            Write("Enter number to repeat:");
            var r = ReadInt();
            for (var j = 0; j < r; j++)
            {
                for (var i = 0; i < number; i++)
                {
                    var row = 1 + i / 3;
                    var column = 1 + i % 3;
                    var id = Properties.App.Default.Total - (column - 1 + (row - 1) * 3);
                    if (Properties.App.Default.IdsToUpdate.Split(',')
                        .Select(x => Convert.ToInt32(x)).Contains(id))
                    {
                        Console.WriteLine("id = " + id);
                        MainRunner.ResetAllHashs(row, column);
                    }
                }
            }
        }

        private static void AddTemplateHashs()
        {
            Write("Enter number to udpate:");
            var number = ReadInt();
            for (var i = 0; i < number; i++)
            {
                var row = 1 + i / 3;
                var column = 1 + i % 3;
                var id = column - 1 + (row - 1) * 3 + 1;
                if (Properties.App.Default.IdsToUpdate.Split(',')
                    .Select(x => Convert.ToInt32(x)).Contains(id))
                {
                    MainRunner.AddTemplateHashs(row, column, Properties.App.Default.TempHashs);
                }
            }
        }

        private static void RemoveTemplateHashs()
        {
            Write("Enter number to udpate:");
            var number = ReadInt();
            for (var i = 0; i < number; i++)
            {
                var row = 1 + i / 3;
                var column = 1 + i % 3;
                var id = column - 1 + (row - 1) * 3 + 1;
                if (Properties.App.Default.IdsToUpdate.Split(',')
                    .Select(x => Convert.ToInt32(x)).Contains(id))
                {
                    MainRunner.RemoveTemplateHashs(row, column, Properties.App.Default.TempHashs);
                }
            }
        }

        public static void Main()
        {
            const string yes = "y";
            var flag = yes;
            while (flag.Equals("y"))
            {
                Clear();
                ValidateData();
                Write("Hello.");
                Write("1 - simple reset hashsets");
                Write("2 - add template hashsets");
                Write("3 - remove template hashsets");
                var option = Read() ?? "1";
                switch (option)
                {
                    case "1":
                    {
                        SimpleResetHashs();
                        break;
                    }
                    case "2":
                    {
                        AddTemplateHashs();
                        break;
                    }
                    case "3":
                    {
                        RemoveTemplateHashs();
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }

                Write("Continue ? (y/n)");
                flag = Read() ?? yes;
                if (!flag.Equals("n") && !flag.Equals("N"))
                {
                    flag = yes;
                }
            }
        }
    }
}