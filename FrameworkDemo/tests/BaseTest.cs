using FrameworkDemo.framework.browser;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Reflection;

namespace FrameworkDemo.tests
{
    public class BaseTest
    {

        //[OneTimeTearDown]
        //public void TakeScreenShot()
        //{
        //    if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
        //    {
        //        ITakesScreenshot ssdriver = Browser.GetInstance().WrappedDriver as ITakesScreenshot;
        //        Screenshot screenshot = ssdriver.GetScreenshot();
        //        string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm");
        //        screenshot.SaveAsFile(@"..\..\..\..\framework\screenshots_fail\" + timestamp +
        //        ".png", ScreenshotImageFormat.Png);
        //    }
        //}
        [TearDown]
        public void TearDown() => Browser.GetInstance().Stop();
    }
}
