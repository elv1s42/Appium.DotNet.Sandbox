using System;
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

        public static RemoteWebDriver UpdateHashs(this RemoteWebDriver d, int number)
        {
            d.OpenProfile();
            for (var i = 0; i < number; i++)
            {
                var row = 1 + i / 3;
                var column = 1 + i % 3;
                var id = Properties.App.Default.Total - (column - 1 + (row - 1) * 3);
                if (Properties.App.Default.IdsToUpdate.Split(',')
                    .Select(x => Convert.ToInt32(x)).Contains(id))
                {
                    Console.WriteLine("id = " + id);
                    string hashs;
                    d.OpenPhoto(row, column)
                 .EditPhoto()
                 .ClearHashtags(out hashs)
                 .SaveEditing()
                 .GoBack()
                 .OpenPhoto(row, column)
                 .EditPhoto()
                 .SetHashtags(hashs, "", column - 1 + (row - 1) * 3)
                 .SaveEditing()
                 .GoBack();
                }
            }
            
            return d;
        }
    }
}