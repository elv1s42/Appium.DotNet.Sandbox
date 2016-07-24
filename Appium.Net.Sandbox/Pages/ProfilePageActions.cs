using System.Linq;
using Appium.Net.Sandbox.Utils;
using OpenQA.Selenium;

namespace Appium.Net.Sandbox.Pages
{
    public static class ProfilePageActions
    {
        public static IWebDriver OpenPhoto(this IWebDriver d, int row, int column)
        {
            return d.DefaultAction("Opening photo...", () =>
            {
                d.FindElements(By.ClassName("android.widget.ImageView"))
                .First(e => e.GetAttribute("name")
                    .Contains($"Photo Thumbnail at Row {row}, Column {column}"))
                .Click();
            });
        }
    }
}