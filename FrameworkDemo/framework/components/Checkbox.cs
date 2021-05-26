using FrameworkDemo.framework.browser;
using OpenQA.Selenium;

namespace FrameworkDemo.framework.components
{
    class Checkbox : CommonPageElement
    {
        public Checkbox(By by) : base(by) { }

        public void SetSelected(bool selected)
        {
            if (selected)
            {
                if (!isSelected())
                {
                    Browser.GetInstance().Click(by);
                }
            }
            else
            {
                if (isSelected())
                {
                    Browser.GetInstance().Click(by);
                }
            }
        }

        public bool isSelected()
        {
            WaitForElementIsVisible(by);
            return Browser.GetInstance().IsSelected(by);
        }
    }
}
