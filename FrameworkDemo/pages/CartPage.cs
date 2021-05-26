using FrameworkDemo.framework.browser;
using FrameworkDemo.framework.components;
using OpenQA.Selenium;
using System;
namespace FrameworkDemo.pages
{
    public class CartPage : BasePage
    {
        private readonly string CART_PAGE_URL = "/cart.php?id";
        private readonly string PRODUCT_NAME_PATTERN = "//div[@class='cart-items']" +
            "//div[@class='cart-item flex valign-center']" +
            "//div[@class='cart-item-product-title']/a[contains(text(), '{0}')]";
        private readonly string PRODUCT_PRICE_PATTERN = "//div[@class='cart-items']" +
            "//div[@class='cart-item flex valign-center']//div[@class='cart-item-product-title']" +
            "/a[contains(text(), '{0}')]/ancestor::div[@class='cart-item flex valign-center']" +
            "//div[@class='cart-item-price']";

        public String GetProductName(string name)
        {
            By product_name_locator = By.XPath(string.Format(PRODUCT_NAME_PATTERN, name));
            Label label = new Label(product_name_locator);
            var resultName = label.GetText();
            return resultName;
        }

        public String GetProductPrice(string name)
        {
            By product_price_locator = By.XPath(string.Format(PRODUCT_PRICE_PATTERN, name));
            Label label = new Label(product_price_locator);
            var resultPrice = label.GetText();
            return resultPrice;
        }

        public CartPage OpenPage()
        {
            Browser.GetInstance().NavigateToUrl(BASE_URL + CART_PAGE_URL);
            return this;
        }
    }
}
