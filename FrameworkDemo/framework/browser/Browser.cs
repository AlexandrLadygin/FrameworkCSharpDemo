using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDemo.framework.browser
{
    class Browser
    {
        private static Browser instance;
        private IWebDriver driver;


        private Browser()
        {
            //сюда добавить инициализацию считываемого значения с консоли (-Dbrowser)
            BrowserType browserType = BrowserType.Firefox;
            driver = WebDriverFactory.GetWorkingDriver(browserType);
        }

        public static Browser GetInstance()
        {
            if(instance == null)
            {
                instance = new Browser();
            }
            return instance;
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }


    }
}
