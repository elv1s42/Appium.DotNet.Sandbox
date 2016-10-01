using System;
using System.Linq;
using System.Threading;
using Appium.Net.Sandbox.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Appium.Net.Sandbox.Pages
{
    public static class PhotoPageActions
    {
        public static RemoteWebDriver GoBack(this RemoteWebDriver d)
        {
            return d.DefaultAction("Going back...", () =>
            {
                d.FindElement(By.Id("com.instagram.android:id/action_bar_button_back"))
                .Click();
            });
        }

        public static RemoteWebDriver ClickParameters(this RemoteWebDriver d)
        {
            return d.DefaultAction("Opening parameters...", () =>
            {
                d.FindElement(By.Id("com.instagram.android:id/media_option_button"))
                .Click();
            });
        }

        public static RemoteWebDriver ClickEdit(this RemoteWebDriver d)
        {
            return d.DefaultAction("Clicking Edit...", () =>
            {
                d.FindElements(By.Id("com.instagram.android:id/row_simple_text_textview"))
                .First(e => e.Text.Equals("Edit"))
                .Click();
            });
        }

        public static RemoteWebDriver EditPhoto(this RemoteWebDriver d)
        {
            return d.ClickParameters().ClickEdit();
        }

        public static RemoteWebDriver ClearHashtags(this RemoteWebDriver d, out string hashs)
        {
            var retry = 0;
            hashs = "";
            while ((hashs == "" || hashs.Contains("Write a caption")) && retry < 10)
            {
                retry++;
                var t = d.FindElement(By.Id("com.instagram.android:id/edit_media_caption"))
                       .Text;
                hashs = t;
            }

            return d.DefaultAction($"Clearing hashtags: '{hashs}' ...", () =>
            {
                d.FindElement(By.Id("com.instagram.android:id/edit_media_caption")).Clear();
            }, "", 5);
        }
        
        public static RemoteWebDriver SetHashtags(this RemoteWebDriver d, string hashs, string tempHashs = "", int number = 0)
        {
            return d.DefaultAction("Setting hashtags ...", () =>
            {
                if (number != 0)
                {
                    hashs = Properties.App.Default.Hashs[number];
                }
                var e = d.FindElement(By.Id("com.instagram.android:id/edit_media_caption"));
                e.Click();
                Thread.Sleep(500);
                var hashsToSet = tempHashs.Equals("") ? hashs : hashs + " " + tempHashs;
                Console.WriteLine("setting: " + hashsToSet);
                e.SendKeys(hashsToSet);
                Thread.Sleep(1000);
                d.FindElement(By.Id("com.instagram.android:id/action_bar_textview_title")).Click();
            });
        }

        public static RemoteWebDriver CloseEditing(this RemoteWebDriver d)
        {
            return d.DefaultAction("Closing Edit...", () =>
            {
                d.FindElement(By.Id("com.instagram.android:id/action_bar_button_back"))
                    .Click();
            });
        }

        public static RemoteWebDriver SaveEditing(this RemoteWebDriver d)
        {
            return d.DefaultAction("Saving Edit...", () =>
            {
                d.FindElement(By.Id("com.instagram.android:id/action_bar_button_action"))
                    .Click();
            });
        }
    }
}