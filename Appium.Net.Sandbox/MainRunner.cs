using System;
using Appium.Net.Sandbox.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace Appium.Net.Sandbox
{
    [TestFixture]
    public class MainRunner
    {
        public RemoteWebDriver Driver;

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

        public void SetUp()
        {
            Driver = new AndroidDriver<AppiumWebElement>(
                       new Uri("http://192.168.1.101:4723/wd/hub"),
                       DesiredCapabilities, TimeSpan.FromSeconds(30));
        }

        public void End()
        {
            Driver.Dispose();
        }

        private void ResetAllHashs(int row, int column)
        {
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

        [Test]
        public void Check()
        {
            ResetAllHashs(10, 3);
        }
        
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(1, 3)]
        [TestCase(2, 1)]
        [TestCase(2, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 1)]
        [TestCase(3, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 1)]
        [TestCase(4, 2)]
        [TestCase(4, 3)]
        [TestCase(5, 1)]
        [TestCase(5, 2)]
        [TestCase(5, 3)]
        [TestCase(6, 1)]
        [TestCase(6, 2)]
        [TestCase(6, 3)]
        [TestCase(7, 1)]
        [TestCase(7, 2)]
        [TestCase(7, 3)]
        [TestCase(8, 1)]
        [TestCase(8, 2)]
        [TestCase(8, 3)]
        [TestCase(9, 1)]
        [TestCase(9, 2)]
        [TestCase(9, 3)]
        [TestCase(10, 1)]
        [TestCase(10, 2)]
        [TestCase(10, 3)]
        [TestCase(11, 1)]
        [TestCase(11, 2)]
        [TestCase(11, 3)]
        [TestCase(12, 1)]
        [TestCase(12, 2)]
        [TestCase(12, 3)]
        [TestCase(13, 1)]
        [TestCase(13, 2)]
        [TestCase(13, 3)]
        [TestCase(14, 1)]
        [TestCase(14, 2)]
        [TestCase(14, 3)]
        [TestCase(15, 1)]
        [TestCase(15, 2)]
        [TestCase(15, 3)]
        [TestCase(16, 1)]
        [TestCase(16, 2)]
        [TestCase(16, 3)]
        [TestCase(17, 1)]
        [TestCase(17, 2)]
        [TestCase(17, 3)]
        [TestCase(18, 1)]
        [TestCase(18, 2)]
        [TestCase(18, 3)]
        [TestCase(19, 1)]
        public void ResetHashs(int row, int column)
        {
            ResetAllHashs(row, column);
        }
    }
}

