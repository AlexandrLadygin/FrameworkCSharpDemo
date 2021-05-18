using FrameworkDemo.framework.browser;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDemo.framework.components
{
    class Button : CommonPageElement
    {
        public Button(By by) : base(by) { }

        public void Click()
        {
            WaitForElementToBeClickable(by);
            Browser.GetInstance().Click(by);
        }

        public void GetText()
        {
            WaitForElementIsVisible(by);
            Browser.GetInstance().GetText(by);
        }
    }
}
