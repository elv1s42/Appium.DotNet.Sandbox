using System;
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
        public IWebDriver D;

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

            D = new RemoteWebDriver(
                new Uri("http://192.168.1.101:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(30));
            
        }

        [Test]
        public void Check()
        {
            D.OpenProfile();
            var els = D.FindElements(By.ClassName("android.widget.ImageView"))
                .Where(e => e.GetAttribute("name").Contains("Миниатюра")).ToList();
            Console.WriteLine("els: " + els.Count);
            foreach (var el in els)
            {
                try
                {
                    Console.WriteLine("e tag: " + el.TagName);
                    Console.WriteLine("e text: " + el.Text);
                    Console.WriteLine("e name: " + el.GetAttribute("name"));
                }
                catch (Exception)
                {
                    
                }
            }

        }

        [OneTimeTearDown]
        public void End()
        {
            D.Dispose();
        }
    }
}

