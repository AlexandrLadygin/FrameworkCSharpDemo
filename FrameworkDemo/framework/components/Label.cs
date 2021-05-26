using FrameworkDemo.framework.browser;
using OpenQA.Selenium;

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
