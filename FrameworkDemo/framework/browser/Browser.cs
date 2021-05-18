using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDemo.framework.browser
{
    class Browser : IWrapsDriver
    {
        private static Browser instance;
        private IWebDriver driver;
        private static readonly string LocatorErrorMessage = "Invalid locator: Locator cannot be null.";


        private Browser()
        {
            //сюда добавить инициализацию считываемого значения с консоли (-Dbrowser)
            BrowserType browserType = BrowserType.Chrome;
            driver = WebDriverFactory.GetWorkingDriver(browserType);
        }

        public IWebDriver WrappedDriver => driver;

        public static Browser GetInstance()
        {
            if(instance == null)instance = new Browser();
 
            return instance;
        }

        public static void Stop()
        {
            if (instance != null) instance.driver.Quit(); 
        }

        public void NavigateToUrl(string url)
        {
            if (url == null) throw new ArgumentNullException("Invalid URL: URL cannot be null.");
            driver.Navigate().GoToUrl(url);
        }

        public void Click(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            IWebElement element = driver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(driver, element);
            highlightedWebElement.Click();
        }

        public void ScrollBy(int p1, int p2)
        {
            string script = string.Format("window.scrollBy({0}, {1})", p1, p2);
            IWebDriver driver = Browser.GetInstance().WrappedDriver;
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("window.scrollBy(0,1000)");
        }

        public void Refresh()
        {
            Browser.GetInstance().WrappedDriver.Navigate().Refresh();
        }

        public void SendKeys(By by, string text)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            if (text == null) throw new ArgumentNullException("Invalid Text: Text cannot be null.");
            IWebElement element = driver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(driver, element);
            highlightedWebElement.SendKeys(text);

        }

        public void Submit(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            IWebElement element = driver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(driver, element);
            highlightedWebElement.Submit();
        }

        public void Clear(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            IWebElement element = driver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(driver, element);
            highlightedWebElement.Clear();
        }

        public string GetText(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            IWebElement element = driver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(driver, element);
            return highlightedWebElement.Text.Trim();
        }

        public bool IsSelected(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            IWebElement element = driver.FindElement(by);
            return element.Selected;
        }
        public void Select(By by, string option)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            if (option == null) throw new ArgumentNullException("Invalid Option: Option cannot be null.");
            Click(by);
            IWebElement element = driver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(driver, element);
            SelectElement dropDownList = new SelectElement(highlightedWebElement);
            dropDownList.SelectByText(option);
        }

        public void MoveToElement(By by)
        {
            Actions actions = new Actions(WrappedDriver);
            IWebElement element = WrappedDriver.FindElement(by);
            actions.MoveToElement(element);
            actions.Perform();
        }
    }
}

