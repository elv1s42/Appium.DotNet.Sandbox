using System.Linq;
using Appium.Net.Sandbox.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace Appium.Net.Sandbox.Pages
{
    public static class ProfilePageActions
    {
        public static RemoteWebDriver OpenPhoto(this RemoteWebDriver d, int row, int column)
        {
            return d.DefaultAction("Opening photo...", () =>
            {
                d.FindElements(By.ClassName("android.widget.ImageView"))
                    .First(e => e.GetAttribute("name")
                        .Contains($"Photo Thumbnail at Row {row}, Column {column}"))
                    .Click();
            }, " Done.", 25, () =>
            {
                ((AndroidDriver<AppiumWebElement>)d).Swipe(100, 750, 100, 100, 1000);
            });
        }
    }
}