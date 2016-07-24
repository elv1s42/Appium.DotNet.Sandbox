using OpenQA.Selenium;

namespace Appium.Net.Sandbox.Pages
{
    public static class PhotoPageActions
    {
        public static IWebDriver GoBack(this IWebDriver d)
        {
            d.FindElement(By.Id("com.instagram.android:id/action_bar_button_back"))
                .Click();
            return d;
        }

        public static IWebDriver ClickParameters(this IWebDriver d)
        {
            d.FindElement(By.Id("com.instagram.android:id/media_option_button"))
                .Click();
            return d;
        }
    }
}