using System;
using OpenQA.Selenium.Remote;

namespace Appium.Net.Sandbox.Utils
{
    public static class ActionHelper
    {
        public static RemoteWebDriver DefaultAction(this RemoteWebDriver d, string msg1, 
            Action a, string msg2 = " Done.", int retry = 1, Action retryAction = null)
        {
            var c = 0;
            while (c < retry)
            {
                try
                {
                    ConsoleLogger.Start(msg1);
                    a.Invoke();
                    ConsoleLogger.Finish(msg2);
                    return d;
                }
                catch
                {
                    c++;
                    retryAction?.Invoke();
                }
            }
            ConsoleLogger.Finish(" Failed!");
            return d;
        }
    }
}
