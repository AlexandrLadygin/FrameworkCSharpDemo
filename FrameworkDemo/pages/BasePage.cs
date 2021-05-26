using FrameworkDemo.framework.components;
using OpenQA.Selenium;
using System;

namespace FrameworkDemo.pages
{
    public abstract class BasePage
    {
        protected readonly string BASE_URL = "https://www.777555.by/";
        private readonly By CART_BUTTON_LOCATOR = By.XPath("//a[@class='h-cart']");
        private readonly By SEARCH_FIELD_LOCATOR = By.XPath("//input[@name='q']");
        private readonly By SEARCH_BUTTON_LOCATOR = By.XPath("//input[@class='button_search']");


        public BasePage TypeTextToSearchField(String textForSearch)
        {
            TextField textField = new TextField(SEARCH_FIELD_LOCATOR);
            textField.SendKeys(textForSearch);
            return this;
        }

        public SearchResultPage ClickSearchButton()
        {
            Button button = new Button(SEARCH_BUTTON_LOCATOR);
            button.Click();
            return new SearchResultPage();
        }

        public CartPage ClickCartButton()
        {
            Button button = new Button(CART_BUTTON_LOCATOR);
            button.Click();
            return new CartPage();
        }
    }
}
