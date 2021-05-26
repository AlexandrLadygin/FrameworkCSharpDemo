using FrameworkDemo.framework.browser;
using OpenQA.Selenium;

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
