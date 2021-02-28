using OpenQA.Selenium;
using System;

namespace WebdriverTask.POM
{
    public class FifthPage : BaseClass
    {
        public FifthPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetFinalBookTitle()
        {
            string xpath = @"//span[contains(@class,'sc-product-title a-text-bold')]";
            return By.XPath(xpath).FindElement(driver).Text;
        }

        public string GetFinalBookPrice()
        {
            string xpath = @"//span[contains(@class,'sc-product-price a-text-bold')]";
            return By.XPath(xpath).FindElement(driver).Text;
        }

        public string GetFinalBookType()
        {
            string xpath = @"//span[contains(@class,'sc-product-binding')]";
            return By.XPath(xpath).FindElement(driver).Text;
        }

        public string GetFinalQuantity()
        {
            string xpath = @"//span[@data-action='a-dropdown-button']";
            string wholeText = driver.FindElement(By.XPath(xpath)).Text;
            string quantity = wholeText.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
            return quantity;
        }

        public string GetTotalPrice()
        {
            string xpath = @"//span[contains(@class,'sc-price-container a-text-bold')]";
            return By.XPath(xpath).FindElement(driver).Text;
        }
    }
}
