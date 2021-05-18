using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
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






    }
}
