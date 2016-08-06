using System;
using Appium.Net.Sandbox.Pages;
using Appium.Net.Sandbox.Utils;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace Appium.Net.Sandbox
{
    public static class EmulatorRunner
    {
        public static RemoteWebDriver Driver;

        public static DesiredCapabilities DesiredCapabilities
        {
            get
            {
                var capabilities = new DesiredCapabilities();
                capabilities.SetCapability("device", "Android");
                capabilities.SetCapability("deviceName", "Nexus 5");
                capabilities.SetCapability("platformName", "Android");
                capabilities.SetCapability("platformVersion", "6.0 Marshmallow");
                capabilities.SetCapability("app", "com.instagram.android");
                capabilities.SetCapability("appActivity", "com.instagram.android.activity.MainTabActivity");
                capabilities.SetCapability("unicodeKeyboard", "true");

                capabilities.SetCapability("ignoreUnimportantViews", true);
                capabilities.SetCapability("disableAndroidWatchers", true);
                return capabilities;
            }
        }

        public static void SetUp()
        {
            Driver = new AndroidDriver<AppiumWebElement>(
                       new Uri("http://192.168.1.101:4723/wd/hub"),
                       DesiredCapabilities, TimeSpan.FromSeconds(180));
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            //Driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, 5));
            //Driver.Manage().Timeouts().SetScriptTimeout(new TimeSpan(0, 0, 5));
        }

        public static void End()
        {
            Driver.Dispose();
        }

        [TestCase(10, 1)]
        public static void ResetAllHashs(int row, int column)
        {
            ConsoleLogger.Write($"Updating photo: row={row}, column={column}");
            SetUp();
            string hashs;
            Driver
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
            End();
        }
    }
}

