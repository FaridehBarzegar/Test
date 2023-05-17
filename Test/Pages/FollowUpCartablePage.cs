using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Pages
{
    public class FollowUpCartablePage
    {
        private IWebDriver driver;
        private  WebDriverWait webDriverWait;
        private IWebElement m_BtnFollowUpCartable => driver.FindElement( By.XPath( "//dt[@class='item empty selected']/a[1]" ));
        public FollowUpCartablePage( IWebDriver driver )
        {
            this.driver = driver;
        }

        public void LoadFollowUpCartable( )
        {
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds(7);
            webDriverWait = new WebDriverWait( driver, TimeSpan.FromSeconds( 7 ) );
            IWebElement m_BtnNewOutgoingLetter= webDriverWait.Until( ExpectedConditions.ElementIsVisible( By.Id( "2bc68c0a-45b6-445d-910f-0813389ba951" )));
            Assert.AreEqual( true, m_BtnFollowUpCartable.Displayed );
            Assert.AreEqual( true, m_BtnNewOutgoingLetter.Displayed );
        }
    }
}
