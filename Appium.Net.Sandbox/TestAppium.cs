using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace Appium.Net.Sandbox
{
    [TestFixture]
    public class TestAppium
    {
        public IWebDriver Driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability("browserName", "chrome");
            capabilities.SetCapability("deviceName", "Nexus 5");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "6.0 Marshmallow");

            Driver = new RemoteWebDriver(
                new Uri("http://192.168.1.101:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
            
        }

        [Test]
        public void FirstTest()
        {
            const string expectedTitle = "GHPR | GitHub Pages Reporter";
            Driver.Navigate().GoToUrl("https://ghpreporter.github.io/");
            Console.WriteLine("Actual Title: " + Driver.Title);
            Console.WriteLine("Expected Title: " + expectedTitle);
            Assert.IsTrue(Driver.Title.Equals(expectedTitle), "Sorry, the website didn't open!!");
        }

        [OneTimeTearDown]
        public void End()
        {
            Driver.Dispose();
        }
    }
}

