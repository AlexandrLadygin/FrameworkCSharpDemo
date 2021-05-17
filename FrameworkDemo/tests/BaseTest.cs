using FrameworkDemo.framework.browser;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace FrameworkDemo.tests
{
    class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = Browser.GetInstance().GetDriver();
        }

        [Test]
        public void BaseTestMethod()
        {

            driver.Navigate().GoToUrl("http://google.com/");
            Console.WriteLine("THE TITLE SHOULD BE......." + driver.Title);
            Assert.That(driver.Title == "Google");
             
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
