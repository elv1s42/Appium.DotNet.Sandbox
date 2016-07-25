using System;
using Appium.Net.Sandbox.Pages;
using NUnit.Framework;
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
            Driver = new RemoteWebDriver(
                new Uri("http://192.168.1.101:4723/wd/hub"), DesiredCapabilities, TimeSpan.FromSeconds(30));
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
        public void ResetHashs(int row, int column)
        {
            ResetAllHashs(row, column);
        }
    }
}

