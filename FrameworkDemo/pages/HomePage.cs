using FrameworkDemo.framework.browser;

namespace FrameworkDemo.pages
{
    public class HomePage : BasePage
    {
        public HomePage OpenPage()
        {
            Browser.GetInstance().NavigateToUrl(BASE_URL);
            return this;
        }
    }
}
