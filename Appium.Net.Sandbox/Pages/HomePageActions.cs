using OpenQA.Selenium;

namespace Appium.Net.Sandbox.Pages
{
    public static class HomePageActions
    {
        public static void OpenProfile(this IWebDriver d)
        {
            var panel = d.FindElement(By.Id("android:id/tabs"));
            panel.FindElement(By.Name("Профиль")).Click();
        }
    }
}