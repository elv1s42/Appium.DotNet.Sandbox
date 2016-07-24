﻿using System;
using System.Linq;
using Appium.Net.Sandbox.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Appium.Net.Sandbox
{
    [TestFixture]
    public class MainRunner
    {
        public IWebDriver Driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability("deviceName", "Nexus 5");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "6.0 Marshmallow");
            capabilities.SetCapability("app", "com.instagram.android");
            capabilities.SetCapability("appActivity", "com.instagram.android.activity.MainTabActivity");

            Driver = new RemoteWebDriver(
                new Uri("http://192.168.1.101:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(30));
            
        }

        [Test]
        public void Check()
        {
            Driver
                .OpenProfile()
                .OpenPhoto(1, 3)
                .GoBack();
        }

        [OneTimeTearDown]
        public void End()
        {
            Driver.Dispose();
        }
    }
}
