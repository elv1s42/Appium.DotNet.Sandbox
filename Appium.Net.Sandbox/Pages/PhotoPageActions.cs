﻿using System;
using System.Linq;
using System.Threading;
using Appium.Net.Sandbox.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;

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

        public static IWebDriver ClickEdit(this IWebDriver d)
        {
            return d.DefaultAction("Clicking Edit...", () =>
            {
                d.FindElements(By.Id("com.instagram.android:id/row_simple_text_textview"))
                .First(e => e.Text.Equals("Edit"))
                .Click();
            });
        }

        public static IWebDriver EditPhoto(this IWebDriver d)
        {
            return d.ClickParameters().ClickEdit();
        }

        public static IWebDriver ClearHashtags(this IWebDriver d, out string hashs)
        {
            var t = d.FindElement(By.Id("com.instagram.android:id/edit_media_caption"))
                   .Text;
            hashs = t;
            return d.DefaultAction($"Clearing hashtags: '{hashs}' ...", () =>
            {
                d.FindElement(By.Id("com.instagram.android:id/edit_media_caption")).Clear();
            });
        }

        public static IWebDriver SetHashtags(this IWebDriver d, string hashs)
        {
            return d.DefaultAction($"Setting hashtags: '{hashs}'...", () =>
            {
                var e = d.FindElement(By.Id("com.instagram.android:id/edit_media_caption"));
                e.Click();
                Thread.Sleep(500);
                e.SendKeys(hashs);
                Thread.Sleep(1000);
                d.FindElement(By.Id("com.instagram.android:id/action_bar_textview_title")).Click();
                
            });
        }

        public static IWebDriver CloseEditing(this IWebDriver d)
        {
            return d.DefaultAction("Closing Edit...", () =>
            {
                d.FindElement(By.Id("com.instagram.android:id/action_bar_button_back"))
                    .Click();
            });
        }

        public static IWebDriver SaveEditing(this IWebDriver d)
        {
            return d.DefaultAction("Saving Edit...", () =>
            {
                d.FindElement(By.Id("com.instagram.android:id/action_bar_button_action"))
                    .Click();
            });
        }
    }
}