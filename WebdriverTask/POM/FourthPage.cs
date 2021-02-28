using OpenQA.Selenium;

namespace WebdriverTask.POM
{
    public class FourthPage : BaseClass
    {
        public FourthPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool AddedToBasketNotification()
        {
            string xpath = @"//h1";
            if (driver.FindElement(By.XPath(xpath)).Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetNotificationText()
        {
            string xpath = @"//h1";
            return By.XPath(xpath).FindElement(driver).Text;
        }

        public string GetCountOfTheItemsInTheBasket()
        {
            string xpath = @"//div[contains(@class,'subcart')]//span[contains(@class,'subtotal')]";
            string wholeText = driver.FindElement(By.XPath(xpath)).Text;
            string[]firstSplit = wholeText.Split(new char[] { ':', ' '});
            string actualCount = firstSplit[2].Trim('(');

            return actualCount;
        }

        public void ClickOnEditBasketButton()
        {
            string xpath = @"//span[@id='hlb-view-cart']";
            driver.FindElement(By.XPath(xpath)).Click();
        }
    }
}
