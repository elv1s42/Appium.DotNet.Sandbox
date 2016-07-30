using System;
using Appium.Net.Sandbox.Utils;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Appium.Net.Sandbox.Pages
{
    public static class Steps
    {
        public static void ResetAllHashs(this AndroidDriver<AppiumWebElement> d, int row, int column)
        {
            try
            {
                ConsoleLogger.Write($"Updating photo: row={row}, column={column}");
                string hashs;
                d
                    .OpenProfile()
                    .OpenPhoto(row, column)
                    .EditPhoto()
                    .ClearHashtags(out hashs)
                    .SaveEditing()
                    .GoBack()
                    .OpenPhoto(row, column)
                    .EditPhoto()
                    .SetHashtags(hashs)
                    .SaveEditing()
                    .GoBack();
            }
            catch (Exception e)
            {
                ConsoleLogger.Message("Error for Resetting hashs!!!");
                ConsoleLogger.Message(e.Message);
                ConsoleLogger.Message(e.StackTrace);
            }
        }
    }
}