using OpenQA.Selenium;

namespace Appium.Net.Sandbox.Pages
{
    public static class HomePageActions
    {
        public static IWebDriver OpenProfile(this IWebDriver d)
        {
            var panel = d.FindElement(By.Id("android:id/tabs"));
            panel.FindElement(By.Name("Profile")).Click();
            return d;
        }
    }
}