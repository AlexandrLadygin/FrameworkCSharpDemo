using FrameworkDemo.framework.browser;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDemo.framework.utils
{
    class FileUtils
    {
        public static void TakeScreenshot(string pathToFolder)
        {
            IWebDriver driver = Browser.GetInstance().WrappedDriver;
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
            string path = string.Format(@"Screensot-{0}{1}.png", pathToFolder, timestamp);
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
        }
    }
}
