using NUnit.Framework;
using OpenQA.Selenium;

namespace WebdriverTask.POM
{
  public class FirstPage : BaseClass
    {
        //IWebDriver driver;

        public FirstPage(IWebDriver driver)            
        {
            this.driver = driver;
        }

        public IWebElement SpyGlassIcon()
        {
            string xpath = @"//input[@value='Go']";
            return driver.FindElement(By.XPath(xpath));
        }
        
        public string SearchBoxXpath = @"//input[@id='twotabsearchtextbox']";

        public void PerformSearch(string textToSearch)
        {
            string xpath = SearchBoxXpath;
            Assert.IsTrue(driver.FindElement(By.XPath(xpath)).Displayed);
            driver.FindElement(By.XPath(xpath)).SendKeys(textToSearch);
            SpyGlassIcon().Click();
        }

        public void ExpandDropdownWithSections()
        {
            string xpath = @"//div[@id='nav-search-dropdown-card']";
            driver.FindElement(By.XPath(xpath)).Click();
        }

        public void SelectSection(string section)
        {
            string xpath = @".//select[@aria-describedby='searchDropdownDescription']//option[.='{0}']";
            string formattedXpath = string.Format(xpath, section);
            driver.FindElement(By.XPath(formattedXpath)).Click();
        }
               
    }
}
