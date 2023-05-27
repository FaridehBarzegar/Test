using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Public;

namespace Test.Pages
{
    public class LogoutPage
    {
        private IWebElement m_BtnExit => driver.FindElement( By.XPath( "//a[contains(.,'خروج')]" ) );
        private IWebDriver driver;
        public LogoutPage(IWebDriver driver )
        {
            this.driver = driver;
        }
        public void LogoutSucceed( )
        {
            driver.ImplicitWaitFor( 5 );
            m_BtnExit.Click( );
       }

    }
}
