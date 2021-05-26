using FrameworkDemo.pages;
using NUnit.Framework;


namespace FrameworkDemo.tests
{
    public class POTests : BaseTest
    {
        [Test]
        public void ZeonTest()
        {
            var iphoneName = "Apple iPhone XR 128GB";
            HomePage homePage = new HomePage();
            homePage.OpenPage();
            homePage.TypeTextToSearchField(iphoneName);
            SearchResultPage searchResultPage = homePage.ClickSearchButton();
            var factName = searchResultPage.GetProductName();
            var factPrice = searchResultPage.GetProductPrice();
            searchResultPage.ClickAddToCartButton();
            CartPage cartPage = searchResultPage.ClickCartButton();
            var actualName = cartPage.GetProductName(iphoneName);
            var actualPrice = cartPage.GetProductPrice(iphoneName);

            Assert.AreEqual(actualPrice, factPrice);
            Assert.AreEqual(actualName, factName);
        }
    }
}
