using OpenQA.Selenium;
using System;
using System.Threading;

namespace WebdriverTask.POM
{
    public class SecondPage : BaseClass
    {
        public SecondPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string BookTitleXpath = @".//div[@data-component-type='s-search-result' and @data-index={0}]//h2//a";

        public string GetBookTitleByBookIndex(int bookIndex)
        {
            Thread.Sleep(2000);
            string xpath = string.Format(BookTitleXpath, bookIndex);
            try
            {
                return By.XPath(xpath).FindElement(driver).Text;
            }
            catch (Exception)
            {
                bookIndex += 1;
                xpath = string.Format(BookTitleXpath, bookIndex);
                return By.XPath(xpath).FindElement(driver).Text;
            }
           
        }

        public void ClickOnBookByIndex(int bookIndex)
        {
            string xpath = string.Format(BookTitleXpath, bookIndex);
            try
            {
                driver.FindElement(By.XPath(xpath)).Click();
            }
            catch
            {
                bookIndex += 1;
                xpath = string.Format(BookTitleXpath, bookIndex);
                driver.FindElement(By.XPath(xpath)).Click();
            }
        }

        public string BadgeXpath = @"//div[@data-index='{0}']//span[@class='a-badge-text']";

        public bool CheckIfBookBadgeExistByBookIndex(int bookIndex)
        {
            Thread.Sleep(1000);
            string xpath = string.Format(BadgeXpath, bookIndex);
            try
            {
                driver.FindElement(By.XPath(xpath));
                return true;
            }
            catch 
            {

                bookIndex += 1;
                xpath = string.Format(BadgeXpath, bookIndex);
                driver.FindElement(By.XPath(xpath));
                return true;
            }
        }

        public string CheckBookPriceForPaperbackCopy()
        {
            string xpath = @"//div[@data-index=2]//a[contains(@class,'a-size-base')]//span[@class='a-price']";
            ScrollToElement(xpath);
            string text = driver.FindElement(By.XPath(xpath)).Text;
            return text;
        }

        public string VerifySelectedType()
        {
            string xpath = @"//div[@id='nav-subnav']//span[text()]";
            return By.XPath(xpath).FindElement(driver).Text;
        }

        


    }
}
