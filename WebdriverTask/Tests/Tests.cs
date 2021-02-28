using NUnit.Framework;
using WebdriverTask.POM;

namespace WebdriverTask
{
    public class Tests : BaseClass
    {

        [Test]
        public void Test1()
        {
            
            FirstPage firstPage = new FirstPage(driver);
            SecondPage secondPage = new SecondPage(driver);
            ThirdPage thirdPage = new ThirdPage(driver);
            FourthPage fourthPage = new FourthPage(driver);
            FifthPage fifthPage = new FifthPage(driver);

            //Go to amazon.co.uk
            Navigate("https://www.amazon.co.uk/");
           
            firstPage.ExpandDropdownWithSections();
            firstPage.SelectSection("Books");
            firstPage.PerformSearch("Harry Potter and the Cursed Child");
            Assert.AreEqual("Books", secondPage.VerifySelectedType());
            string bookTitle = secondPage.GetBookTitleByBookIndex(1);
            Assert.IsTrue(bookTitle.Contains("Harry Potter and the Cursed Child - Parts One and Two"));
            Assert.IsTrue(secondPage.CheckIfBookBadgeExistByBookIndex(1));
            secondPage.ClickOnBookByIndex(1);
            thirdPage.SelectBookType("Paperback");
            Assert.AreEqual(bookTitle, thirdPage.BookTitle());
            Assert.IsTrue(thirdPage.DoesBookBadgeExistAtOpenedItem());
            string bookPrice = thirdPage.GetBookPrice();
            Assert.AreEqual("£4.00", bookPrice);
            string bookType = thirdPage.GetBookType();
            Assert.AreEqual("Paperback", bookType);
            thirdPage.ClickAddToBasketButton();
            Assert.IsTrue(fourthPage.AddedToBasketNotification());
            Assert.AreEqual("Added to Basket", fourthPage.GetNotificationText());
            Assert.AreEqual("1", fourthPage.GetCountOfTheItemsInTheBasket());
            fourthPage.ClickOnEditBasketButton();
            Assert.AreEqual(bookTitle, fifthPage.GetFinalBookTitle());
            Assert.AreEqual(bookType, fifthPage.GetFinalBookType());
            Assert.AreEqual(bookPrice, fifthPage.GetFinalBookPrice());
            Assert.AreEqual("1", fifthPage.GetFinalQuantity());
            Assert.AreEqual("£4.00", fifthPage.GetTotalPrice());
        }
    }
}