using FrameworkDemo.framework.browser;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDemo.framework.components
{
    class Label : CommonPageElement
    {
        public Label(By by) : base(by) { }

        public string GetText()
        {
            WaitForElementIsVisible(by);
            return Browser.GetInstance().GetText(by);
        }
    }
}
