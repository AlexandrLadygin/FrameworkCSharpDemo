using FrameworkDemo.framework.components;
using OpenQA.Selenium;
using System;

namespace FrameworkDemo.pages
{
    public class SearchResultPage : BasePage
    {
        private readonly By PRODUCT_TITLE_LOCATOR = By.XPath("//div[@class='pr-card-title']/h1");
        private readonly By PRODUCT_PRICE_LOCATOR = By.XPath("//div[@class='pr-card-price-block']/div[@class='pr-card-price']");
        private readonly By ADD_TO_CART_BUTTON = By.XPath("//a[@id='but_car_main']");

    public String GetProductName()
        {
            Label label = new Label(PRODUCT_TITLE_LOCATOR);
            var name = label.GetText();
            return name;
        }

        public String GetProductPrice()
        {
            Label label = new Label(PRODUCT_PRICE_LOCATOR);
            var price = label.GetText();
            return price;
        }

        public SearchResultPage ClickAddToCartButton()
        {
            Button button = new Button(ADD_TO_CART_BUTTON);
            button.Click();
            return this;
        }
    }
}
