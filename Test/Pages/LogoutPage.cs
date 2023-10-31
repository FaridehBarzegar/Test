using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Public;
using Test.Tools;

namespace Test.Pages
{
	public static class LogoutPage
    {
        private static  IWebElement m_btnExit =>  Driver.Instance.FindElement( By.LinkText( "خروج" ));
       
        internal static void  LogoutSucceed( IWebDriver webDriver )
        {
            m_btnExit.Click( );
            IWebElement txtUserName= webDriver.WaitForLoadAnElementById("Username" , "UserName In LoginPage");
            ErrorDetector.Detect();
            Assert.That(txtUserName.Displayed,Is.EqualTo(true));
       }

    }
}
