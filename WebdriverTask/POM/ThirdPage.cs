using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace WebdriverTask.POM
{
    public class ThirdPage : BaseClass
    {
        public ThirdPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectBookType(string bookType)
        {
            string xpath = @".//ul[contains(@class,'unordered-list')]//li[contains(@class,'swatchElement')]//a//span[.='{0}']";
            string formattedXpath = string.Format(xpath, bookType);
            Assert.IsTrue(driver.FindElement(By.XPath(formattedXpath)).Displayed);
            By.XPath(formattedXpath).FindElement(driver).Click();
        }

        public string BookTitleXpath = @".//h1//span[@id='productTitle']";

        public string BookTitle()
        {
            try
            {
                return By.XPath(BookTitleXpath).FindElement(driver).Text;
            }
            catch
            {

                Thread.Sleep(1000);
                return By.XPath(BookTitleXpath).FindElement(driver).Text;
            }

        }

        public bool DoesBookBadgeExistAtOpenedItem()
        {
            Thread.Sleep(1000);
            string xpath = @".//i[contains(@class,'best-seller-badge')]";
            if (driver.FindElement(By.XPath(xpath)).Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetBookPrice()
        {
            string xpath = @"//ul[contains(@class,'a-unordered')]//li[contains(@class,' selected')]//span[contains(@class,'a-button-inner')]//span[text()]//span";
            return By.XPath(xpath).FindElement(driver).Text;
        }

        public string GetBookType()
        {
            string xpath = @"//ul[contains(@class,'a-unordered')]//li[contains(@class,' selected')]//span[contains(@class,'a-button-inner')]//a//span[text()][1]";
            string formattedXpath = string.Format(xpath);
            return By.XPath(formattedXpath).FindElement(driver).Text;
        }

        public void ClickAddToBasketButton()
        {
            string xpath = @"//div[@class='a-button-stack']//span[@id='submit.add-to-cart']";
            IWebElement element = driver.FindElement(By.XPath(xpath));
            Actions actions = new Actions(driver);
            ScrollToElement(xpath);
            actions.MoveToElement(element).Click().Perform();

        }

    }
}
