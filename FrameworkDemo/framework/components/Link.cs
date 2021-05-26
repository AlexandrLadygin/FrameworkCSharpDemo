using FrameworkDemo.framework.browser;
using OpenQA.Selenium;

namespace FrameworkDemo.framework.components
{
    class Link : CommonPageElement
    {
        public Link(By by) : base(by) { }

        public void Click()
        {
            WaitForElementToBeClickable(by);
            Browser.GetInstance().Click(by);
        }

        public string GetText()
        {
            WaitForElementIsVisible(by);
            return Browser.GetInstance().GetText(by);
        }
    }
}
