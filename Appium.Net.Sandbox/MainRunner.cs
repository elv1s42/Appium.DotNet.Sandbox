﻿using System;
using System.Configuration;
using Appium.Net.Sandbox.Pages;
using Appium.Net.Sandbox.Utils;
using Castle.DynamicProxy.Generators.Emitters;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace Appium.Net.Sandbox
{
    public static class MainRunner
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
                return capabilities;
            }
        }

        public static void SetUp()
        {
            var url = Properties.App.Default.Url;
            Driver = new AndroidDriver<AppiumWebElement>(new Uri(url), DesiredCapabilities, TimeSpan.FromSeconds(30));
        }

        public static void End()
        {
            Driver.Dispose();
        }

        public static void ResetAllHashs(int row, int column)
        {
            try
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
            catch (Exception e)
            {
                ConsoleLogger.Message("Error for Resetting hashs!!!");
                ConsoleLogger.Message(e.Message);
                ConsoleLogger.Message(e.StackTrace);
            }
        }
    }
}

