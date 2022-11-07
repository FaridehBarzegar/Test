using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test
{
    public class Tests
    {
        public IWebDriver  driver;

        [ SetUp]
        public void Setup( )
        {
            driver = new ChromeDriver( );
            driver.Manage( ).Window.Maximize( );
            driver.Navigate( ).GoToUrl( "https://192.168.12.145" );
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds(5 );

        }

        [Test]
        public void Test1( )
        {
            driver.FindElement(By.Name( "Username" ) ).SendKeys("administrator");
            driver.FindElement( By.Id( "Password" ) ).SendKeys("1");
            driver.FindElement( By.Id( "login-button" ) ).Click();
            string element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[1]/div[1]")).Text;

            Console.WriteLine( element );


            Assert.AreEqual( element, "\r\n        سازمان الکترونیک پیوست\r\n    " );
;            ;
        }
    }
}