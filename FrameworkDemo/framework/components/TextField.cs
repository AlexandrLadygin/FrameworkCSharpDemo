﻿using FrameworkDemo.framework.browser;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDemo.framework.components
{
    class TextField : CommonPageElement
    {
        public TextField(By by) : base(by) { }

        public void Clear()
        {
            WaitForElementIsVisible(by);
            Browser.GetInstance().Clear(by);

        }
        public void SendKeys(string text)
        {
            if (text == null) throw new ArgumentNullException("Invalid Text: Text cannot be null.");
            WaitForElementExists(by);
            Browser.GetInstance().SendKeys(by, text);
        }

        public void Submit()
        {
            WaitForElementExists(by);
            Browser.GetInstance().Submit(by);
        }

        public string GetText => GetAttribute(by, "value");

    }
}
