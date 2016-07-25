using Appium.Net.Sandbox.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Appium.Net.Sandbox.Pages
{
    public static class HomePageActions
    {
        public static RemoteWebDriver OpenProfile(this RemoteWebDriver driver)
        {
            return driver.DefaultAction("Opening profile...", () =>
            {
                var panel = driver.FindElement(By.Id("android:id/tabs"));
                panel.FindElement(By.Name("Profile")).Click();
            });
        }
    }
}