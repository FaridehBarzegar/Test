using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Pages
{

    public class ShellPage
    {
        private IWebDriver driver;
        public ShellPage( IWebDriver driver )
        {
            this.driver = driver;
        }
        private IWebElement m_BtnOfficeAutomation => driver.FindElement( By.Id( "OfficeAutomation" ));
        private IWebElement m_BtnCalender => driver.FindElement( By.Id( "Calendar" ));
        private IWebElement m_BtPersonelInbox => driver.FindElement( By.Id( "PersonalInbox" ));
        private IWebElement m_BtnPeople => driver.FindElement( By.Id( "People" ));
        private IWebElement m_BtnNote => driver.FindElement( By.Id( "Note" ));
        private IWebElement m_BtnBulletinBoard => driver.FindElement( By.Id( "BulletinBoard" ));
        private IWebElement m_BtnChengePassword => driver.FindElement( By.LinkText( "تغییر کلمه عبور" ));
        private IWebElement m_BtnUserProperties => driver.FindElement( By.Id( "anchor-userTitle" ));
        private IWebElement m_BtnExit => driver.FindElement( By.XPath( "//a[contains(.,'خروج')]" ));

        public void ShellPageLoad( )
        {
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 5 );
            Assert.AreEqual( true, m_BtnOfficeAutomation.Displayed );
            Assert.AreEqual( true, m_BtnCalender.Displayed );
            Assert.AreEqual( true, m_BtPersonelInbox.Displayed );
            Assert.AreEqual( true, m_BtnPeople.Displayed );
            Assert.AreEqual( true, m_BtnNote.Displayed );
            Assert.AreEqual( true, m_BtnBulletinBoard.Displayed );
            Assert.AreEqual( true, m_BtnChengePassword.Displayed );
            Assert.AreEqual( true, m_BtnUserProperties.Displayed );
            Assert.AreEqual( true, m_BtnExit.Displayed );
        }

        public void OpenOfficeAutomation( )
        {
            m_BtnOfficeAutomation.Click( );
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 5 );
        }
        //public void LogOut( )
        //{
        //    driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 5 );
        //    m_BtnExit.Click( );
        //}









































































































    }
}
