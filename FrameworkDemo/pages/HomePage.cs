using FrameworkDemo.framework.browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
