using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace FrameworkDemo.framework.browser
{
    class Browser : IWrapsDriver
    {
        private IWebDriver driver;
        private static ThreadLocal<Browser> instance = new ThreadLocal<Browser>();
        private static readonly string LocatorErrorMessage = "Invalid locator: Locator cannot be null.";

        private Browser()
        {
            //сюда добавить считывание типа браузера с консоли --params:Browser=Chrome
            BrowserType browserType = BrowserType.Chrome;
            driver = WebDriverFactory.GetWorkingDriver(browserType);
            //log.Debug("Creating instance of WebDriver with ChromeDriver.");
        }

        public IWebDriver WrappedDriver => driver;

           public static Browser GetInstance()
        {
            //log.Debug("Getting instance of browser.");
            if (instance.Value == null) instance.Value = new Browser();
            return instance.Value;
        }

        public static void Stop()
        {
            //log.Debug("Stopping the browser.");
            try
            {
                if (instance != null) instance.Value.WrappedDriver.Quit();
            }
            finally
            {
                instance.Dispose();
            }
        }

            public void NavigateToUrl(string url)
        {
            if (url == null) throw new ArgumentNullException("Invalid URL: URL cannot be null.");
            //log.Debug("Navigating to: " + url);
            driver.Navigate().GoToUrl(url);
        }

        public void Click(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            //log.Debug("Click on element: " + by);
            IWebElement element = driver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(driver, element);
            highlightedWebElement.Click();
        }

        public void Refresh()
        {
            //log.Debug("Refresh");
            Browser.GetInstance().WrappedDriver.Navigate().Refresh();
        }

        public void SendKeys(By by, string text)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            if (text == null) throw new ArgumentNullException("Invalid Text: Text cannot be null.");
            //log.Debug("Send keys: " + text + " to element: " + by);
            IWebElement element = driver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(driver, element);
            highlightedWebElement.SendKeys(text);

        }

        public void Clear(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            //log.Debug("Clearing field: " + by);
            IWebElement element = driver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(driver, element);
            highlightedWebElement.Clear();
        }

        public string GetText(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            //log.Debug("Getting the text of element: " + by);
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
            //log.Debug("Selecting option item - " + option);
            Click(by);
            IWebElement element = driver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(driver, element);
            SelectElement dropDownList = new SelectElement(highlightedWebElement);
            dropDownList.SelectByText(option);
        }
    }
}
