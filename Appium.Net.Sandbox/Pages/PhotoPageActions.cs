using Appium.Net.Sandbox.Utils;
using OpenQA.Selenium;

namespace Appium.Net.Sandbox.Pages
{
    public static class PhotoPageActions
    {
        public static IWebDriver GoBack(this IWebDriver d)
        {
            return d.DefaultAction("Going back...", () =>
            {
                d.FindElement(By.Id("com.instagram.android:id/action_bar_button_back"))
                .Click();
            });
        }

        public static IWebDriver ClickParameters(this IWebDriver d)
        {
            return d.DefaultAction("Opening parameters...", () =>
            {
                d.FindElement(By.Id("com.instagram.android:id/media_option_button"))
                .Click();
            });
        }
    }
}