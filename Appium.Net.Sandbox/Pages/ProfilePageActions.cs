using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Appium.Net.Sandbox.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Remote;

namespace Appium.Net.Sandbox.Pages
{
    public static class ProfilePageActions
    {
        public static RemoteWebDriver OpenPhoto(this RemoteWebDriver d, int row, int column)
        {
            return d.DefaultAction("Opening photo...", () =>
            {
                d.FindElements(By.ClassName("android.widget.ImageView"))
                    .First(e => e.GetAttribute("name")
                        .Contains($"Photo Thumbnail at Row {row}, Column {column}"))
                    .Click();
            }, " Done.", 5, () =>
            {
                var ad = new AndroidDriver<AppiumWebElement>(
                    new Uri("http://192.168.1.101:4723/wd/hub"), 
                    MainRunner.DesiredCapabilities, TimeSpan.FromSeconds(30));

                ad.ScrollTo($"Photo Thumbnail at Row {row}, Column {column}");
            });
        }
    }
}