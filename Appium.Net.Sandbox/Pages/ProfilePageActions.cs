using System.Linq;
using OpenQA.Selenium;

namespace Appium.Net.Sandbox.Pages
{
    public static class ProfilePageActions
    {
        public static IWebDriver OpenPhoto(this IWebDriver d, int row, int column)
        {
            d.FindElements(By.ClassName("android.widget.ImageView"))
                .First(e => e.GetAttribute("name")
                    .Contains($"Photo Thumbnail at Row {row}, Column {column}"))
                .Click();
            return d;
        }
    }
}