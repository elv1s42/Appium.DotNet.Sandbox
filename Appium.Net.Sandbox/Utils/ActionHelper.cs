using System;
using OpenQA.Selenium;

namespace Appium.Net.Sandbox.Utils
{
    public static class ActionHelper
    {
        public static IWebDriver DefaultAction(this IWebDriver d, string msg1, 
            Action a, string msg2 = " Done.")
        {
            ConsoleLogger.Start(msg1);
            a.Invoke();
            ConsoleLogger.Finish(msg2);
            return d;
        }
    }
}
