using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace WebdriverTask
{
    public class BaseClass
    {
        protected IWebDriver driver;

        [SetUp]
        public void InitializeDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public void Navigate(string url)
        {
            driver.Url = url;
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
        }

        public void ScrollToElement(string xpath)
        {          
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath(xpath)));
        }       

    }
}
