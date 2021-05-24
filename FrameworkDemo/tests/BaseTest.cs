using FrameworkDemo.framework.browser;
using FrameworkDemo.framework.utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Reflection;

namespace FrameworkDemo.tests
{
    public class BaseTest
    {

        [TearDown]
        public void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                FileUtils.TakeScreenshot(@"..\..\..\..\FrameworkDemo\");      
        }

        [OneTimeTearDown]
        public void TearDown() => Browser.GetInstance().Stop();
    }
}
