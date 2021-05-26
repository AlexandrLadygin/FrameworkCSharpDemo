using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace FrameworkDemo.framework.browser
{
    class WebDriverFactory
    {
        public static IWebDriver GetWorkingDriver (BrowserType type)
        {
            IWebDriver driver = null;
            switch (type)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException(String.Format("{0} is not valid browser", type));
            }
            //driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
