using Appium.Net.Sandbox.Utils;
using OpenQA.Selenium;

namespace Appium.Net.Sandbox.Pages
{
    public static class HomePageActions
    {
        public static IWebDriver OpenProfile(this IWebDriver driver)
        {
            return driver.DefaultAction("Opening profile...", () =>
            {
                var panel = driver.FindElement(By.Id("android:id/tabs"));
                panel.FindElement(By.Name("Profile")).Click();
            });
        }
    }
}